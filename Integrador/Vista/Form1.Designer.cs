namespace Vista
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanelOrden = new FlowLayoutPanel();
            groupBoxProductos = new GroupBox();
            flowLayoutPanelProductos = new FlowLayoutPanel();
            groupBoxOrden = new GroupBox();
            btnDeleteOrden = new Button();
            btnCargarOrden = new Button();
            btnNuevoProducto = new Button();
            groupBoxProductos.SuspendLayout();
            groupBoxOrden.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelOrden
            // 
            flowLayoutPanelOrden.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelOrden.Location = new Point(6, 12);
            flowLayoutPanelOrden.Name = "flowLayoutPanelOrden";
            flowLayoutPanelOrden.Size = new Size(245, 400);
            flowLayoutPanelOrden.TabIndex = 0;
            // 
            // groupBoxProductos
            // 
            groupBoxProductos.Controls.Add(flowLayoutPanelProductos);
            groupBoxProductos.Location = new Point(2, 3);
            groupBoxProductos.Name = "groupBoxProductos";
            groupBoxProductos.Size = new Size(553, 418);
            groupBoxProductos.TabIndex = 1;
            groupBoxProductos.TabStop = false;
            // 
            // flowLayoutPanelProductos
            // 
            flowLayoutPanelProductos.AutoScroll = true;
            flowLayoutPanelProductos.Location = new Point(0, 9);
            flowLayoutPanelProductos.Name = "flowLayoutPanelProductos";
            flowLayoutPanelProductos.Size = new Size(547, 403);
            flowLayoutPanelProductos.TabIndex = 0;
            // 
            // groupBoxOrden
            // 
            groupBoxOrden.Controls.Add(flowLayoutPanelOrden);
            groupBoxOrden.Location = new Point(561, 3);
            groupBoxOrden.Name = "groupBoxOrden";
            groupBoxOrden.Size = new Size(258, 418);
            groupBoxOrden.TabIndex = 2;
            groupBoxOrden.TabStop = false;
            // 
            // btnDeleteOrden
            // 
            btnDeleteOrden.Location = new Point(567, 422);
            btnDeleteOrden.Name = "btnDeleteOrden";
            btnDeleteOrden.Size = new Size(116, 25);
            btnDeleteOrden.TabIndex = 3;
            btnDeleteOrden.Text = "Borrar";
            btnDeleteOrden.UseVisualStyleBackColor = true;
            btnDeleteOrden.Click += btnDeleteOrden_Click;
            // 
            // btnCargarOrden
            // 
            btnCargarOrden.Location = new Point(696, 422);
            btnCargarOrden.Name = "btnCargarOrden";
            btnCargarOrden.Size = new Size(116, 25);
            btnCargarOrden.TabIndex = 4;
            btnCargarOrden.Text = "Finaliza pedido";
            btnCargarOrden.UseVisualStyleBackColor = true;
            btnCargarOrden.Click += btnCargarOrden_Click;
            // 
            // btnNuevoProducto
            // 
            btnNuevoProducto.Location = new Point(12, 422);
            btnNuevoProducto.Name = "btnNuevoProducto";
            btnNuevoProducto.Size = new Size(116, 25);
            btnNuevoProducto.TabIndex = 5;
            btnNuevoProducto.Text = "Nuevo Producto";
            btnNuevoProducto.UseVisualStyleBackColor = true;
            btnNuevoProducto.Click += btnNuevoProducto_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 455);
            Controls.Add(btnNuevoProducto);
            Controls.Add(btnCargarOrden);
            Controls.Add(btnDeleteOrden);
            Controls.Add(groupBoxOrden);
            Controls.Add(groupBoxProductos);
            Name = "Form1";
            Text = "Cajero";
            Load += Form1_Load;
            groupBoxProductos.ResumeLayout(false);
            groupBoxOrden.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelOrden;
        private GroupBox groupBoxProductos;
        private FlowLayoutPanel flowLayoutPanelProductos;
        private GroupBox groupBoxOrden;
        private Button btnDeleteOrden;
        private Button btnCargarOrden;
        private Button btnNuevoProducto;
    }
}