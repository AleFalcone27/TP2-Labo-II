using Entidades;
using System.Text;

namespace Vista
{
    public partial class Form1 : Form
    {

        private ToolTip toolTip;
        Orden orden = new Orden("Alejo"); //MODIFICAR ESTO


        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Producto.GetAndInitializeProducts();
                CreateProductosUI(Producto.Productos);
            }
            catch (ErrorDeConexionException ex)
            {
                MessageBox.Show(ex.Message);
                
            }

        }

        
        /*  PRODUCTOS  */

        public void CreateProductosUI(List<Producto> productos)
        {

            flowLayoutPanelProductos.FlowDirection = FlowDirection.LeftToRight;

            flowLayoutPanelProductos.WrapContents = true;
            flowLayoutPanelProductos.Dock = DockStyle.Fill;


            foreach (var producto in productos)
            {
                int id = 1;

                // Botones
                Button button = new Button();
                button.Name = producto.Nombre;
                button.Text = producto.Nombre;
                button.Height = 100;
                button.Width = 100;
                button.Click += ProductoButtonClick;

                // Menu desplegable 
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Detalles");
                menu.Name = producto.Nombre;
                button.ContextMenuStrip = menu; // Reemplaza textBox1 con el nombre de tu control
                menu.ItemClicked += Menu_ItemClicked;

                // Descripcion
                InitializeToolTip(producto, button);

                // Agregamos los botones al flowPanel
                flowLayoutPanelProductos.Controls.Add(button);
            }

            // Agregamos el flowPanel al groupBox
            groupBoxProductos.Controls.Add(flowLayoutPanelOrden);
            this.Controls.Add(groupBoxProductos);
        }
       
        private void InitializeToolTip(Producto producto, Button button)
        {
            toolTip = new ToolTip();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Precio: $" + producto.Precio.ToString());
            toolTip.SetToolTip(button, $"{sb}");
        }


        // Menu desplegable 

        private void Menu_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            
            foreach (Producto producto in Producto.Productos)
            {
                if (e.ClickedItem.Text == "Detalles")
                {
                    if (sender.ToString().Contains(producto.Nombre))
                    {
                        StringBuilder info = new StringBuilder();
                        info.AppendLine(producto.Nombre);
                        info.AppendLine("- Condimentos: " + producto.Condimentos);
                        info.AppendLine("- Ingredientes: " + producto.Ingredientes);

                        MessageBox.Show(info.ToString());
                    }
                }
            }
        }
        private void ProductoButtonClick(object? sender, EventArgs e)
        {

            string nombreProducto = sender.ToString().Substring(35);

            foreach (var producto in Producto.Productos)
            {
                if (producto == nombreProducto)
                {
                    orden.AgregarALaOrden(producto);
                    //MessageBox.Show(producto.Condimentos);
                }
            }

            CreateOrdenUI();
        }



        /* ORDEN */

        public void CreateOrdenUI()
        {
            flowLayoutPanelOrden.Controls.Clear();

            foreach (var item in orden.GetOrden)
            {

                Label label = new Label();
                label.Width = flowLayoutPanelOrden.Width;
                StringBuilder sb = new StringBuilder();
                sb.Append($"{item.Nombre}: {item.Precio}");
                label.Text = sb.ToString();

                flowLayoutPanelOrden.Controls.Add(label);

            }

            Label labelSeparador = new Label();
            labelSeparador.Text = "------------------------";
            labelSeparador.Width = flowLayoutPanelOrden.Width;
            labelSeparador.Anchor = AnchorStyles.Bottom;

            Label labelTotal = new Label();
            labelTotal.Text = $"Total: {Math.Round(orden.Total, 2)}";
            labelTotal.Width = flowLayoutPanelOrden.Width;
            labelTotal.Anchor = AnchorStyles.Bottom;

            flowLayoutPanelOrden.Controls.Add(labelSeparador);
            flowLayoutPanelOrden.Controls.Add(labelTotal);

            groupBoxOrden.Controls.Add(flowLayoutPanelOrden);

            orden.ResetTotal();

        }

        private void btnCargarOrden_Click(object sender, EventArgs e)
        {
            orden.InsertarOrden();
        }






        private void btnDeleteOrden_Click(object sender, EventArgs e)
        {
            flowLayoutPanelOrden.Controls.Clear();
            orden.GetOrden.Clear();
            orden.ResetTotal();
        }

       

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            FormNuevoProducto formNuevoProducto = new FormNuevoProducto();
            formNuevoProducto.Show();
        }
    }
}