using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;


namespace Entidades
{
    public class Orden
    {
        private List<Producto> ListOrden;
        private double total;
        private string nombre;

        public Orden(string nombre)
        {
            this.ListOrden = new List<Producto>();
            this.nombre = nombre;
        }

        public List<Producto> GetOrden
        {
            get { return this.ListOrden; }
            set { this.ListOrden = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
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

            //if (this.dictOrden.Count == 0)
            //{

            //    this.dictOrden.Add(productoAAgregar, 1);
            //}
            //else
            //{

            //    if (this.dictOrden.ContainsKey(productoAAgregar))
            //    {

            //        int cantItems = this.dictOrden[productoAAgregar];
            //        this.dictOrden[productoAAgregar] = cantItems + 1;
            //    }
            //    else
            //    {
            //        this.dictOrden.Add(productoAAgregar, 1);
            //    }
            //}
        }


        //    public void InsertarOrden()
        //    {
        //        using (SqlConnection connection = new SqlConnection(GestorSql.ConnectionString))
        //        {
        //            try
        //            {
        //                connection.Open();

        //                string queryInsertOrden = "INSERT INTO Orden(FechaPedido, NombreCliente) VALUES(@Fecha, @NombreCliente); SELECT SCOPE_IDENTITY();";
        //                SqlCommand cmdInsertOrden = new SqlCommand(queryInsertOrden, connection);
        //                cmdInsertOrden.Parameters.AddWithValue("@Fecha", DateTime.Now);
        //                cmdInsertOrden.Parameters.AddWithValue("@NombreCliente", this.nombre);

        //                // Obtener el último ID insertado en la tabla Orden
        //                int ultimoOrdenID = Convert.ToInt32(cmdInsertOrden.ExecuteScalar());

        //                // Insertar en la tabla DetalleOrden 


        //                foreach (var producto in this.GetOrden)
        //                {
        //                    string queryInsertDetalleOrden = "INSERT INTO DetalleOrden(DetalleID, OrdenID, Producto, Cantidad) VALUES(@DetalleID, @OrdenID, @Producto, @Cantidad);";

        //                    StringBuilder sb = new StringBuilder();

        //                    Dictionary<string, string> dict = new Dictionary<string, string>();

        //                    dict["Producto"] = $"{producto.Key.Nombre}";
        //                    dict["Producto"] = $"{producto.Key.Condimentos}";
        //                    dict["Producto"] = $"{producto.Key.Ingredientes}";
        //                    dict["Producto"] = $"{producto.Key.Precio}";
        //                    dict["Producto"] = $"{producto.Key.EsVegano}";


        //                    SqlCommand cmdInsertDetalleOrden = new SqlCommand(queryInsertDetalleOrden, connection);


        //                    cmdInsertDetalleOrden.Parameters.AddWithValue("@OrdenID", ultimoOrdenID);
        //                    cmdInsertDetalleOrden.Parameters.AddWithValue("@Producto", $"{dict}");
        //                    cmdInsertDetalleOrden.Parameters.AddWithValue("@Cantidad", producto.Value);
        //                    cmdInsertDetalleOrden.ExecuteNonQuery();

        //                }


        //                connection.Close();
        //            }
        //            catch (Exception)
        //            {
        //                throw new ErrorDeConexionException("Error de conexión");
        //            }
        //        }
        //    }
        //}

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
                }
                //catch (Exception)
                //{
                //    throw new ErrorDeConexionException("Error de conexión");
                //}
            }
        }

        }
    


//INSERT INTO Orden(OrdenID, FechaPedido, OtrosCampos) VALUES(1, '2023-11-11', 'Alejo');
//INSERT INTO DetalleOrden(DetalleID, OrdenID, NombreProducto, Cantidad) VALUES(1, 1, 'Producto A', 5);
//INSERT INTO DetalleOrden(DetalleID, OrdenID, NombreProducto, Cantidad) VALUES(2, 1, 'Producto B', 10);