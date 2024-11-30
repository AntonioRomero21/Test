namespace BeldenCableInspection.Controls
{
    partial class TitleBar
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
            this.tablePanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.tablePanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanelTop
            // 
            this.tablePanelTop.BackColor = System.Drawing.Color.Transparent;
            this.tablePanelTop.ColumnCount = 3;
            this.tablePanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tablePanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanelTop.Controls.Add(this.panelLogo, 0, 0);
            this.tablePanelTop.Controls.Add(this.buttonClose, 2, 0);
            this.tablePanelTop.Controls.Add(this.title, 1, 0);
            this.tablePanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelTop.Location = new System.Drawing.Point(0, 0);
            this.tablePanelTop.Margin = new System.Windows.Forms.Padding(0);
            this.tablePanelTop.MaximumSize = new System.Drawing.Size(0, 72);
            this.tablePanelTop.MinimumSize = new System.Drawing.Size(1280, 72);
            this.tablePanelTop.Name = "tablePanelTop";
            this.tablePanelTop.RowCount = 1;
            this.tablePanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelTop.Size = new System.Drawing.Size(1280, 72);
            this.tablePanelTop.TabIndex = 5;
            // 
            // panelLogo
            // 
            this.panelLogo.BackgroundImage = global::BeldenCableInspection.Properties.Resources.CESAT_Logo;
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(256, 72);
            this.panelLogo.TabIndex = 6;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackgroundImage = global::BeldenCableInspection.Properties.Resources.CloseButton;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(1233, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(32, 72);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(259, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(971, 72);
            this.title.TabIndex = 9;
            this.title.Text = "BELDEN Family Products Tester";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(155)))));
            this.Controls.Add(this.tablePanelTop);
            this.Name = "TitleBar";
            this.Size = new System.Drawing.Size(1280, 72);
            this.tablePanelTop.ResumeLayout(false);
            this.tablePanelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tablePanelTop;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label title;
    }
}
