using System.Runtime.CompilerServices;

namespace Vista
{
    partial class FormNuevoProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtIngredientes = new TextBox();
            txtCondimentos = new TextBox();
            rbtnVeganoSi = new RadioButton();
            rbtnVeganoNo = new RadioButton();
            label1 = new Label();
            btnAgregar = new Button();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(25, 21);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(328, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(25, 59);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "Precio";
            txtPrecio.Size = new Size(328, 23);
            txtPrecio.TabIndex = 1;
            // 
            // txtIngredientes
            // 
            txtIngredientes.Location = new Point(25, 99);
            txtIngredientes.Name = "txtIngredientes";
            txtIngredientes.PlaceholderText = "Ingredientes";
            txtIngredientes.Size = new Size(328, 23);
            txtIngredientes.TabIndex = 2;
            // 
            // txtCondimentos
            // 
            txtCondimentos.Location = new Point(25, 143);
            txtCondimentos.Name = "txtCondimentos";
            txtCondimentos.PlaceholderText = "Condimentos";
            txtCondimentos.Size = new Size(328, 23);
            txtCondimentos.TabIndex = 3;
            // 
            // rbtnVeganoSi
            // 
            rbtnVeganoSi.AutoSize = true;
            rbtnVeganoSi.Location = new Point(91, 190);
            rbtnVeganoSi.Name = "rbtnVeganoSi";
            rbtnVeganoSi.Size = new Size(34, 19);
            rbtnVeganoSi.TabIndex = 5;
            rbtnVeganoSi.TabStop = true;
            rbtnVeganoSi.Text = "Si";
            rbtnVeganoSi.UseVisualStyleBackColor = true;
            rbtnVeganoSi.CheckedChanged += rbtnVeganoSi_CheckedChanged;
            // 
            // rbtnVeganoNo
            // 
            rbtnVeganoNo.AutoSize = true;
            rbtnVeganoNo.Location = new Point(141, 190);
            rbtnVeganoNo.Name = "rbtnVeganoNo";
            rbtnVeganoNo.Size = new Size(41, 19);
            rbtnVeganoNo.TabIndex = 6;
            rbtnVeganoNo.TabStop = true;
            rbtnVeganoNo.Text = "No";
            rbtnVeganoNo.UseVisualStyleBackColor = true;
            rbtnVeganoNo.CheckedChanged += rbtnVeganoNo_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 192);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 7;
            label1.Text = "Vegano";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(207, 187);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(146, 24);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // FormNuevoProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 223);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(rbtnVeganoNo);
            Controls.Add(rbtnVeganoSi);
            Controls.Add(txtCondimentos);
            Controls.Add(txtIngredientes);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Name = "FormNuevoProducto";
            Text = "Nuevo producto";
            FormClosing += FormNuevoProducto_FormClosing;
            Load += FormNuevoProducto_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtIngredientes;
        private TextBox txtCondimentos;
        private RadioButton rbtnVeganoSi;
        private RadioButton rbtnVeganoNo;
        private Label label1;
        private Button btnAgregar;
    }
}