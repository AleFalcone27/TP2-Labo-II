using System.Net.Http.Headers;

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
        }

        public Dictionary<Producto, int> SetOrden
        {
            set { this.dictOrden = value; }
        }


        public double GetTotal
        {
            get {

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

    }




}


//INSERT INTO Orden(OrdenID, FechaPedido, OtrosCampos) VALUES(1, '2023-11-11', 'Otros datos de la orden');
//INSERT INTO DetalleOrden(DetalleID, OrdenID, NombreProducto, Cantidad) VALUES(1, 1, 'Producto A', 5);
//INSERT INTO DetalleOrden(DetalleID, OrdenID, NombreProducto, Cantidad) VALUES(2, 1, 'Producto B', 10);