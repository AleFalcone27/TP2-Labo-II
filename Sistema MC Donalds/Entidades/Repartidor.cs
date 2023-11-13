using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Repartidor : Persona
    {
        string codigoRepartidor;
        string nombreCliente;

        public Repartidor(string nombre, float precioTotal, int pedido, string codigoRepartidor, string nombreCliente) : base(nombre, precioTotal, pedido)
        {
            this.codigoRepartidor = codigoRepartidor;
            this.nombreCliente = nombreCliente;
        }

        public override string GetNombre { get { return this.nombreCliente; } }

        public override string GetPrecioTotal { get { return this.GetPrecioTotal.ToString(); } }

    }
}
