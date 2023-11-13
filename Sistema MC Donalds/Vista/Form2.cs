using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Form2 : Form
    {

        private static int cantidadInstancias = 0;


        public static int CantidadInstacias { get { return Form2.cantidadInstancias;  } }


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cantidadInstancias++;
        }

        public void AbrirFormularioOrden()
        {
            
        }


    }
}
