namespace Gestion_De_Farmacia_Grupo3
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbRegistroProductos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbRegistroProductos
            // 
            this.lbRegistroProductos.AutoSize = true;
            this.lbRegistroProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbRegistroProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegistroProductos.ForeColor = System.Drawing.SystemColors.Control;
            this.lbRegistroProductos.Location = new System.Drawing.Point(-2, -2);
            this.lbRegistroProductos.Name = "lbRegistroProductos";
            this.lbRegistroProductos.Size = new System.Drawing.Size(284, 29);
            this.lbRegistroProductos.TabIndex = 0;
            this.lbRegistroProductos.Text = "Registro de Productos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 654);
            this.Controls.Add(this.lbRegistroProductos);
            this.Name = "Form1";
            this.Text = "Registro de Productos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRegistroProductos;
    }
}

