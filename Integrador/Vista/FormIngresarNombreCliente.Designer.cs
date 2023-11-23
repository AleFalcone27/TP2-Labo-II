namespace Vista
{
    partial class FormIngresarNombreCliente
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
            txtName = new TextBox();
            btnIngresar = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(27, 22);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "NOMBRE DEL CLIENTE";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 0;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(63, 69);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(121, 29);
            btnIngresar.TabIndex = 1;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // FormIngresarNombreCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 110);
            Controls.Add(btnIngresar);
            Controls.Add(txtName);
            Name = "FormIngresarNombreCliente";
            Text = "! BIENVENIDO ¡";
            Load += IngresarNombreCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Button btnIngresar;
    }
}