using Entidades;
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
    public partial class FormNuevoProducto : Form
    {

        public FormNuevoProducto()
        {
            InitializeComponent();
        }

        private bool isVegan = false;

        private void FormNuevoProducto_Load(object sender, EventArgs e)
        {
            this.rbtnVeganoNo.Checked = true; // Por defecto los nuevos productos no son veganos
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (float.TryParse(txtPrecio.Text, out float precio))
            {
                Producto nuevoProducto = new Producto(txtNombre.Text, txtIngredientes.Text, precio, txtCondimentos.Text, this.isVegan);
                Producto.insertProductsInDB(nuevoProducto);
                Producto.Productos.Add(nuevoProducto);
                //Create productos ui
                MessageBox.Show("Se agrego correctamente");
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void rbtnVeganoSi_CheckedChanged(object sender, EventArgs e)
        {
            isVegan = true;
        }

        private void rbtnVeganoNo_CheckedChanged(object sender, EventArgs e)
        {
            isVegan = false;
        }

        private void FormNuevoProducto_FormClosing(object sender, FormClosingEventArgs e)
        {

           
        }
    }
}
