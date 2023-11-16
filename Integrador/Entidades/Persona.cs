using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {

        private string nombre;
        private float precioTotal;
        private int pedido;

        protected Persona(string nombre, float precioTota, int pedido)
        {
            this.nombre = nombre;
            this.precioTotal = precioTota;
            this.pedido = pedido;
        }

        abstract public string GetNombre { get; }
        abstract public string GetPrecioTotal { get; }


        // Agregar 
        
    }



}
