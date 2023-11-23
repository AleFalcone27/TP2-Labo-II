using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        private string nombre;

        protected Persona(string nombre, float precioTota, int pedido)
        {
            this.nombre = nombre;
        }

        public string Nombre { get; }

    }
}
