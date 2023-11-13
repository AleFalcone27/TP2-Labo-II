using Entidades;
using System.Collections.Generic;
using System.Text;

namespace Vista
{
    public partial class Form1 : Form
    {

        private string ultimoItem;
        private ToolTip toolTip;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Producto.GetAndInitializeProducts();
            CreateProductosUI(Producto.Productos);
        }

        Orden orden = new Orden(); //MODIFICAR ESTO

        public void CreateProductosUI(List<Producto> productos)
        {

            flowLayoutPanelProductos.FlowDirection = FlowDirection.LeftToRight;

            flowLayoutPanelProductos.WrapContents = true;
            flowLayoutPanelProductos.Dock = DockStyle.Fill;

            foreach (var producto in productos)
            {
                Button button = new Button();

                button.Click += ProductoButtonClick;
                button.Name = producto.Id.ToString();
                button.Text = producto.Nombre;
                button.Height = 100;
                button.Width = 100;

                flowLayoutPanelProductos.Controls.Add(button);
                InitializeToolTip(producto,button);

            }

            groupBoxProductos.Controls.Add(flowLayoutPanelOrden);
            this.Controls.Add(groupBoxProductos);
        }

        private void InitializeToolTip(Producto producto,Button button)
        {
            toolTip = new ToolTip();

            // Agregar la lista de ingredientes a la base de datos de productos
            toolTip.SetToolTip(button, $"{producto.Nombre}");
        }





        private void ProductoButtonClick(object? sender, EventArgs e)
        {
            string consulta;

            string nombreProducto = sender.ToString().Substring(35);


            foreach (var producto in Producto.Productos)
            {
                if (producto == nombreProducto)
                {
                    orden.AgregarALaOrden(producto);
                }
            }

            CreateOrdenUI();
        }

        public void CreateOrdenUI()
        {
            flowLayoutPanelOrden.Controls.Clear();

            foreach (var item in orden.GetOrden)
            {

                Label label = new Label();
                label.Width = flowLayoutPanelOrden.Width;
                StringBuilder sb = new StringBuilder();
                sb.Append($"{item.Key.Nombre} x{item.Value}    {item.Key.Precio}");
                label.Text = sb.ToString();
                this.ultimoItem = item.Key.Nombre;

                flowLayoutPanelOrden.Controls.Add(label);

            }

            Label labelSeparador = new Label();
            labelSeparador.Text = "------------------------";
            labelSeparador.Width = flowLayoutPanelOrden.Width;
            labelSeparador.Anchor = AnchorStyles.Bottom;


            Label labelTotal = new Label();
            labelTotal.Text = $"Total: {Math.Round(orden.GetTotal,2)}";
            labelTotal.Width = flowLayoutPanelOrden.Width;
            labelTotal.Anchor = AnchorStyles.Bottom;

            flowLayoutPanelOrden.Controls.Add(labelSeparador);
            flowLayoutPanelOrden.Controls.Add(labelTotal);

            groupBoxOrden.Controls.Add(flowLayoutPanelOrden);

            orden.ResetTotal();

        }

        private void btnDeleteOrden_Click(object sender, EventArgs e)
        {
            flowLayoutPanelOrden.Controls.Clear();
            orden.GetOrden.Clear();
            orden.ResetTotal();
        }
    }
}