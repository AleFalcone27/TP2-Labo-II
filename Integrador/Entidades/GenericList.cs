using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class GenericList<T> : IEnumerable<T> where T : class
    {
        private List<T> list;

        public GenericList()
        {
            this.list = new List<T>();
        }

        /// <summary>
        /// Agrega un item a la lista
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            list.Add(item);
        }

        /// <summary>
        /// Elimina todos los elementos de nuestra lista
        /// </summary>
        public void Clear()
        {
            list.Clear();   
        }

        // Nos permite hacer una iteración simple en una collección o tipo espeficico
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        // Implementación de la interfaz IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
