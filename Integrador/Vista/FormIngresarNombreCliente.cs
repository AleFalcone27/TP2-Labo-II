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
    public partial class FormIngresarNombreCliente : Form
    {

        string nombre;


        public string Nombre
        {
            get { return this.nombre; }
        }

        public FormIngresarNombreCliente()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.BringToFront();
        }

        private void IngresarNombreCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.nombre = txtName.Text;
            this.Close();   
        }
    }
}
