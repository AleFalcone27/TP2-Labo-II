using System.Data.SqlClient;


namespace Entidades
{
    public class Orden
    {
        private Dictionary<Producto, int> dictOrden;
        private double total;

        public Orden()
        {
            this.dictOrden = new Dictionary<Producto, int>();
        }

        public Dictionary<Producto, int> GetOrden
        {
            get { return this.dictOrden; }
            set { this.dictOrden = value; }
        }

        public double Total
        {

            set { this.total = value; } 

            get
            {

                foreach (var item in this.dictOrden)
                {
                    if (item.Value == 1)
                    {
                        this.total += item.Key.Precio;
                    }
                    else
                    {
                        this.total += item.Key.Precio * item.Value;
                    }


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
            if (this.dictOrden.Count == 0)
            {

                this.dictOrden.Add(productoAAgregar, 1);
            }
            else
            {

                if (this.dictOrden.ContainsKey(productoAAgregar))
                {

                    int cantItems = this.dictOrden[productoAAgregar];
                    this.dictOrden[productoAAgregar] = cantItems + 1;
                }
                else
                {
                    this.dictOrden.Add(productoAAgregar, 1);
                }
            }
        }

        public void insertOrden()
        {
            //using (SqlConnection connection = new SqlConnection(GestorSql.ConnectionString))
            //{

            //    string jsonProductos = JsonConvert.SerializeObject(this.dictOrden); // Convertir el diccionario a formato JSON

            //    string query = "INSERT INTO Orden(FechaPedido, Productos) VALUES(@Fecha, @Productos);";

            //    SqlCommand command = new SqlCommand(query, connection);
            //    command.Parameters.AddWithValue("@Fecha", DateTime.Now);
            //    command.Parameters.AddWithValue("@Productos", jsonProductos);

            //    connection.Open();
            //    command.ExecuteNonQuery();

            //    //PROBAR UNA SERIALIZACION XML Y LUEGO GUARDARLO EN LA TABLA 

            //}

        }


    }




}


//INSERT INTO Orden(OrdenID, FechaPedido, OtrosCampos) VALUES(1, '2023-11-11', 'Alejo');
//INSERT INTO DetalleOrden(DetalleID, OrdenID, NombreProducto, Cantidad) VALUES(1, 1, 'Producto A', 5);
//INSERT INTO DetalleOrden(DetalleID, OrdenID, NombreProducto, Cantidad) VALUES(2, 1, 'Producto B', 10);