namespace BeldenCableInspection.Views
{
    partial class Emergency
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
            this.message = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.instructions = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.BackColor = System.Drawing.Color.Transparent;
            this.message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.message.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.Transparent;
            this.message.Location = new System.Drawing.Point(0, 0);
            this.message.Margin = new System.Windows.Forms.Padding(0);
            this.message.Name = "message";
            this.message.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.message.Size = new System.Drawing.Size(1280, 132);
            this.message.TabIndex = 11;
            this.message.Text = "message";
            this.message.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Red;
            this.panelLeft.ColumnCount = 1;
            this.panelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLeft.Controls.Add(this.message, 0, 0);
            this.panelLeft.Controls.Add(this.instructions, 0, 2);
            this.panelLeft.Controls.Add(this.panel1, 0, 1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.RowCount = 3;
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelLeft.Size = new System.Drawing.Size(1280, 663);
            this.panelLeft.TabIndex = 8;
            // 
            // instructions
            // 
            this.instructions.AutoSize = true;
            this.instructions.BackColor = System.Drawing.Color.Transparent;
            this.instructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instructions.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructions.ForeColor = System.Drawing.Color.Transparent;
            this.instructions.Location = new System.Drawing.Point(0, 529);
            this.instructions.Margin = new System.Windows.Forms.Padding(0);
            this.instructions.Name = "instructions";
            this.instructions.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.instructions.Size = new System.Drawing.Size(1280, 134);
            this.instructions.TabIndex = 12;
            this.instructions.Text = "instructions";
            this.instructions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BeldenCableInspection.Properties.Resources.estop2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 391);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeft_Paint);
            // 
            // Emergency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelLeft);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Emergency";
            this.Size = new System.Drawing.Size(1280, 663);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label message;
        private System.Windows.Forms.TableLayoutPanel panelLeft;
        private System.Windows.Forms.Label instructions;
        private System.Windows.Forms.Panel panel1;
    }
}
