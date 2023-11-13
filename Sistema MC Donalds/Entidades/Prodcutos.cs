using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Entidades
{
    public class Producto
    {
        private int id;
        private string nombre;
        private string ingredientes;
        private double precio;
        private bool vegano;
        private static List<Producto> productos;


        static Producto()
        {
            Producto.productos = new List<Producto>();
        }

        public Producto(int id, string nombre, string ingredientes ,double precio, bool vegano)
        {
            this.id = id;
            this.nombre = nombre;
            this.ingredientes = ingredientes;
            this.precio = precio;
            this.vegano = vegano;
        }

        public string Nombre { get { return this.nombre; } }
        public  double Precio { get { return this.precio; } }
        public  string Ingredientes { get { return this.ingredientes; } }
        public int Id { get { return this.id; } }

        public static List<Producto> Productos { get { return productos; } }


        public static void GetAndInitializeProducts()
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
                            int id = reader.GetInt32(0);
                            string nombre = reader.GetString(1);
                            string? ingredientes = reader.GetString(2);
                            double precio = reader.GetDouble(3);
                            bool vegano = reader.GetBoolean(4);

                            Producto producto = new Producto(id, nombre, ingredientes , precio, vegano);
                            Producto.productos.Add(producto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener productos: " + ex.Message);
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

        public static bool operator !=(Producto p1, string p2)
        {
            return p1.Nombre == p2;
        }

    }
}


