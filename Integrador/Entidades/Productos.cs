using System.Data.SqlClient;

namespace Entidades
{
    public class Producto 
    {
        /* Atributos */ 
        private string nombre;
        private string ingredientes;
        private string condimentos;
        private double precio;
        private bool vegano;
        private static List<Producto> productos;

        /* Constructores */

        static Producto()
        {
            Producto.productos = new List<Producto>();
        }

        public Producto(string nombre, string ingredientes, double precio, string condimentos, bool vegano)
        {
            this.nombre = nombre;
            this.condimentos = condimentos;
            this.ingredientes = ingredientes;
            this.precio = precio;
            this.vegano = vegano;
        }

        /* Getters & Setters */

        public string Nombre { get { return this.nombre; } }
        public double Precio { get { return this.precio; } }

 
        public string Condimentos
        {
            get { return this.condimentos; }
            set { this.condimentos = value; }
        }


        public bool EsVegano
        {
            get { return this.vegano; }
        }

  
        public string Ingredientes { get { return this.ingredientes; } }

   
        public static List<Producto> Productos { get { return productos; } }


        /* Métodos */

        /// <summary>
        /// Levanta de la base de datos todos los registros, crea instancias de Producto y los agrega a una lista
        /// </summary>
        /// <returns> True si pudo generar la conexión, de lo contrario False</returns>
        /// <exception cref="ErrorDeConexionException"></exception>
        public static bool GetAndInitializeProducts()
        {
            using (SqlConnection connection = new SqlConnection(GestorSql.ConnectionString))
            {
                try
                {
                    string query = "SELECT * FROM Productos";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string nombre = reader.GetString(1);
                            string? ingredientes = reader.GetString(2);
                            double precio = reader.GetDouble(3);
                            string condimentos = reader.GetString(4);
                            bool vegano = reader.GetBoolean(5);

                            Producto producto = new Producto(nombre, ingredientes, precio, condimentos, vegano);

                            Producto.Productos.Add(producto);
                        }
                        return true;
                    }
                }

                catch (Exception ex)
                {
                throw new ErrorDeConexionException("Error de conexión a la Base de datos");
                }
            }
            return false;
        }

        /// <summary>
        /// Inserta productos en la base de datos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns> True si pudo insertarlos, de lo contrario False</returns>
        public static bool insertProductsInDB(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(GestorSql.ConnectionString))
            {
                try
                {
                    string query = "INSERT INTO Productos (Nombre, Ingredientes, Precio, Condimentos, Vegano) " +
                          "VALUES (@Nombre, @Ingredientes, @Precio, @Condimentos .@Vegano)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Ingredientes", producto.ingredientes);
                    command.Parameters.AddWithValue("@Precio", producto.precio);
                    command.Parameters.AddWithValue("@Ingredientes", producto.condimentos);
                    command.Parameters.AddWithValue("@Vegano", producto.vegano);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al guardar el nuevo producto: " + ex.Message);
                    return false;
                }
            }
        }



        /// <summary>
        /// Compara entre el nombre de una instancia de Producto y un string
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True si el nombre del producto es igual al string, caso contrario False</returns>
        public static bool operator ==(Producto p1, string p2)
        {
            return p1.Nombre == p2;
        }

        // Sobrecarga de operadores
        /// <summary>
        /// Compara entre el nombre de una instancia de Producto y un string
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True si el nombre del producto es igual al string, caso contrario False</returns>
        public static bool operator !=(Producto p1, string p2)
        {
            return p1.Nombre != p2;
        }



    }
}


