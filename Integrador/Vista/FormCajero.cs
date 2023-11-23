using Entidades;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormCajero : Form
    {

        private ToolTip toolTip;
        Orden orden = new Orden("Cliente"); 


        public FormCajero()
        {
            InitializeComponent();
        }


        public void Form1_Load(object? sender, EventArgs e)
        {
            try
            {
                this.CenterToScreen();
                Producto.GetAndInitializeProducts();
                this.CreateProductosUI(Producto.Productos);
                FormIngresarNombreClienteInit();
            }
            catch (ErrorDeConexionException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        /*  PRODUCTOS  */

        /// <summary>
        /// Itera la lista de productos y por cada uno genera un boton en la UI y los agrega al groupbox y al flowLayoutPanle
        /// </summary>
        /// <param name="productos"></param>
        public void CreateProductosUI(List<Producto> productos)
        {
            flowLayoutPanelProductos.FlowDirection = FlowDirection.LeftToRight;

            flowLayoutPanelProductos.WrapContents = true;
            flowLayoutPanelProductos.Dock = DockStyle.Fill;


            foreach (var producto in productos)
            {
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
                button.ContextMenuStrip = menu; 
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
      
        /// <summary>
        /// Crea el texto de preview cuando pasamos el mousse por sobre los productos en nuestra UI
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="button"></param>
        private void InitializeToolTip(Producto producto, Button button)
        {
            toolTip = new ToolTip();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Precio: $" + producto.Precio.ToString());
            toolTip.SetToolTip(button, $"{sb}");
        }


        /* MENÚ DESPLEGABLE */

        /// <summary>
        /// Genera un MessageBox con detalles de cada producto al hacer clicl derecho sobre alguno de de estos en nuestra UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Agrega a la orden el producto al cual clikeemos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductoButtonClick(object? sender, EventArgs e)
        {

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


        /* ORDEN */

        /// <summary>
        /// Itera la lista de orden, la cual contiene todos los elementos que agregamos a la misma y tambien se encarga de 
        /// mostrar estos cambios en la UI
        /// </summary>
        public void CreateOrdenUI()
        {
            
            this.flowLayoutPanelOrden.Controls.Clear();

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

        /// <summary>
        /// Muestra un mensaje en relación a la impresión del ticket y limpia la lista de la orden y el total para preparanos para tomar una nueva orden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarOrden_Click(object sender, EventArgs e)
        {
            orden.InsertarOrden();
            if (orden.ImprimirTicket())
            {
                MessageBox.Show("Imprimiendo Ticket");
            }
            else MessageBox.Show("Error al imprimir Ticket");

            btnDeleteOrden_Click();
            FormIngresarNombreClienteInit();
        }

        /// <summary>
        /// Limpia la UI de la orden, su lista y el total de la misma
        /// </summary>
        private void btnDeleteOrden_Click()
        {
            flowLayoutPanelOrden.Controls.Clear();
            orden.GetOrden.Clear();
            orden.ResetTotal();
        }

        /// <summary>
        /// Limpia la UI de la orden, su lista y el total de la misma
        /// </summary>
        private void btnDeleteOrden_Click(object sender, EventArgs e)
        {
            flowLayoutPanelOrden.Controls.Clear();
            orden.GetOrden.Clear();
            orden.ResetTotal();
        }


        /* NUEVO PRODUCTO */

        /// <summary>
        /// Genera un formulario para cargar un nuevo producto, se encarga de actualizar la UI para que este nuevo producto aparezca en la misma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanelProductos.Controls.Clear();
            Producto.Productos.Clear();

            FormNuevoProducto formNuevoProducto = new FormNuevoProducto();
            formNuevoProducto.ShowDialog();

            Producto.GetAndInitializeProducts();
            this.CreateProductosUI(Producto.Productos);
        }


        /* NUEVA ORDEN */

        /// <summary>
        /// Crea una instancia de ingresarNombreCliente lo muestra, y guarda el input en nuestra instancia de orden 
        /// </summary>
        private void FormIngresarNombreClienteInit()
        {
            FormIngresarNombreCliente ingresarNombreCliente = new FormIngresarNombreCliente();
            ingresarNombreCliente.ShowDialog();
            orden.Nombre = ingresarNombreCliente.Nombre;
        }

    }
}