namespace BeldenCableInspection.Views
{
    partial class Loading
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.instructions = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelLeft.ColumnCount = 1;
            this.panelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelLeft.Controls.Add(this.instructions, 0, 0);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.RowCount = 1;
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelLeft.Size = new System.Drawing.Size(1280, 663);
            this.panelLeft.TabIndex = 8;
            this.panelLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeft_Paint);
            // 
            // instructions
            // 
            this.instructions.AutoSize = true;
            this.instructions.BackColor = System.Drawing.Color.Transparent;
            this.instructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instructions.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(107)))), ((int)(((byte)(0)))));
            this.instructions.Location = new System.Drawing.Point(0, 0);
            this.instructions.Margin = new System.Windows.Forms.Padding(0);
            this.instructions.Name = "instructions";
            this.instructions.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.instructions.Size = new System.Drawing.Size(1280, 663);
            this.instructions.TabIndex = 10;
            this.instructions.Text = "Loading devices...";
            this.instructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelLeft);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Loading";
            this.Size = new System.Drawing.Size(1280, 663);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelLeft;
        private System.Windows.Forms.Label instructions;
    }
}
