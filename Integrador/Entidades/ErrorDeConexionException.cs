using Microsoft.VisualBasic;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ErrorDeConexionException : Exception
    {
        public ErrorDeConexionException(string msg): base(msg)
        {
            
        }
    }
}
