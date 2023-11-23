using System.Data.SqlClient;


namespace Entidades
{
    public class Orden
    {
        private GenericList<Producto> ListOrden;
        private double total;
        private string nombre;

        public Orden(string nombre)
        {
            this.ListOrden = new GenericList<Producto>();
            this.nombre = nombre;
        }

        public GenericList<Producto> GetOrden
        {
            get { return this.ListOrden; }
            set { this.ListOrden = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }


        public double Total
        {

            set { this.total = value; }

            get
            {

                foreach (var item in this.ListOrden)
                {

                    this.total += item.Precio;

                }
                return this.total;
            }
        }

        public void ResetTotal()
        {
            this.total = 0;
        }

        public void AgregarALaOrden(Producto productoAAgregar)
        {
            this.ListOrden.Add(productoAAgregar);
        }

        public void InsertarOrden()
        {
            using (SqlConnection connection = new SqlConnection(GestorSql.ConnectionString))
            {
                //try
                //{
                    connection.Open();

                    string queryInsertOrden = "INSERT INTO Orden(FechaPedido, NombreCliente) VALUES(@Fecha, @NombreCliente); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdInsertOrden = new SqlCommand(queryInsertOrden, connection);
                    cmdInsertOrden.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmdInsertOrden.Parameters.AddWithValue("@NombreCliente", this.nombre);

                    // Obtener el último ID insertado en la tabla Orden
                    int ultimoOrdenID = Convert.ToInt32(cmdInsertOrden.ExecuteScalar());

                    string queryInsertDetalleOrden = "INSERT INTO DetalleOrden(OrdenID, Producto) VALUES(@OrdenID, @Producto);";
                    SqlCommand cmdInsertDetalleOrden = new SqlCommand(queryInsertDetalleOrden, connection);

                    foreach (var producto in this.GetOrden)
                    {
                        // Construir una cadena de texto para representar los detalles del producto
                        string detallesProducto = $"{producto.Nombre}- {producto.Condimentos}- {producto.Ingredientes}- {producto.Precio}- {producto.EsVegano}";

                        // Establecer parámetros para la inserción en DetalleOrden
                        cmdInsertDetalleOrden.Parameters.Clear();
                        cmdInsertDetalleOrden.Parameters.AddWithValue("@OrdenID", ultimoOrdenID);
                        cmdInsertDetalleOrden.Parameters.AddWithValue("@Producto", detallesProducto);
                        cmdInsertDetalleOrden.ExecuteNonQuery();
                    }

                    connection.Close();
                //}
                //catch (Exception)
                //{
                //    throw new ErrorDeConexionException("Error de conexión");
                //}
            }
        }

        private List<string> GetOrdenFromDB()
        {
            using (SqlConnection connection = new SqlConnection(GestorSql.ConnectionString))
            {
                try
                {
                    string query = "SELECT TOP 1 * FROM Orden ORDER BY OrdenID DESC;";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<string> result = new List<string>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetInt32(0).ToString());
                            result.Add(reader.GetDateTime(1).ToString());
                            result.Add(reader.GetString(2).ToString());
                        }
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    throw new ErrorDeConexionException("Error de conexión a la base de datos");
                }
                return new List<string>();
            }
        }

        private List<string> GetDetallesOrdenFromDB(int id)
        {
            using (SqlConnection connection = new SqlConnection(GestorSql.ConnectionString))
            {
                try
                {
                    string query = $"SELECT * FROM DetalleOrden WHERE OrdenId = {id};";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<string> result = new List<string>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //result.Add(reader.GetInt32(0).ToString());
                            //result.Add(reader.GetInt32(1).ToString());

                            string producto = reader.GetString(2);

                            string[] palabras = producto.Split('-');

                            result.Add(palabras[0]);

                        }
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    throw new ErrorDeConexionException("Error de conexión a la base de datos");
                }
                return null;
            }
        }

        public bool ImprimirTicket()
        {
            List<string> listaOrden = new List<string>();
            List<string> listaDetalleOrden = new List<string>();

            listaOrden = GetOrdenFromDB();
            listaDetalleOrden = GetDetallesOrdenFromDB(int.Parse(listaOrden[0]));

            // La ruta relativa no me funciona

            string directorioActual = @"C:\Users\aleef\OneDrive\Escritorio\2do Cuatri\TP2-Labo-II\Integrador\Tickets";
            string rutaRelativa = Path.Combine(directorioActual, $"TicketOrdenNro_{listaOrden[0]}.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(rutaRelativa))
                {
                    writer.WriteLine("-----------------------------------");
                    writer.WriteLine($"Fecha de compra: {listaOrden[1]}");
                    writer.WriteLine($"Nombre del cliente: {listaOrden[2]}");

                    // Escribir detalles de productos si existen en la lista de detalles
                    if (listaDetalleOrden.Count > 0)
                    {
                        writer.WriteLine("Productos:");
                        foreach (string producto in listaDetalleOrden)
                        {
                            writer.WriteLine($"- {producto}");
                        }
                    }
                    else
                    {
                        writer.WriteLine("Sin detalles de productos.");
                    }

                    writer.WriteLine($"Total: {this.Total}");

                    writer.WriteLine("-----------------------------------");
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al imprimir el ticket", ex);
            }
        }
    }
}





//INSERT INTO Orden(OrdenID, FechaPedido, OtrosCampos) VALUES(1, '2023-11-11', 'Alejo');
//INSERT INTO DetalleOrden(DetalleID, OrdenID, NombreProducto, Cantidad) VALUES(1, 1, 'Producto A', 5);
//INSERT INTO DetalleOrden(DetalleID, OrdenID, NombreProducto, Cantidad) VALUES(2, 1, 'Producto B', 10);