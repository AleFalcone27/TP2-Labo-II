using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClienteFisico : Persona
    {
        public ClienteFisico(string nombre, float precioTotal, int pedido) : base(nombre,precioTotal,pedido)
        {
        
        }

        public override string GetNombre => throw new NotImplementedException();

        public override string GetPrecioTotal => throw new NotImplementedException();

    }
}
