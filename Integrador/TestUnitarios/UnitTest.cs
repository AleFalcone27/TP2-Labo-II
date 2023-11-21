using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Solo va a devovler true si encuentra algun registro dentro de la tabla Productos
        /// </summary>
        [TestMethod]
        public void GetAndInitializeProducts_deberiaDevolverTrue()
        {
            bool ret = Producto.GetAndInitializeProducts();

            Assert.AreEqual(ret,true);
        }

        /// <summary>
        /// Testea el reseteo del total de la orden 
        /// </summary>
        [TestMethod]
        public void ResetTotal_deberiaSerCero()
        {
            Orden orden = new Orden("Prueba");

            orden.Total = 100;

            orden.ResetTotal();

            Assert.AreEqual(orden.Total, 0); 
        }
    }
}