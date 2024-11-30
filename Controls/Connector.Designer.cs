namespace BeldenCableInspection.Controls
{
    partial class Connector
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
            this.ring = new System.Windows.Forms.PictureBox();
            this.body = new System.Windows.Forms.Button();
            this.pole4 = new BeldenCableInspection.Controls.Pole();
            this.pole3 = new BeldenCableInspection.Controls.Pole();
            this.pole5 = new BeldenCableInspection.Controls.Pole();
            this.pole1 = new BeldenCableInspection.Controls.Pole();
            this.pole2 = new BeldenCableInspection.Controls.Pole();
            ((System.ComponentModel.ISupportInitialize)(this.ring)).BeginInit();
            this.SuspendLayout();
            // 
            // ring
            // 
            this.ring.Image = global::BeldenCableInspection.Properties.Resources.ConnectorOff_min;
            this.ring.Location = new System.Drawing.Point(0, 0);
            this.ring.Name = "ring";
            this.ring.Size = new System.Drawing.Size(320, 320);
            this.ring.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ring.TabIndex = 0;
            this.ring.TabStop = false;
            this.ring.Click += new System.EventHandler(this.ring_Click);
            // 
            // body
            // 
            this.body.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.body.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.body.ForeColor = System.Drawing.Color.Transparent;
            this.body.Location = new System.Drawing.Point(278, 3);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(42, 42);
            this.body.TabIndex = 1;
            this.body.Text = "Body";
            this.body.UseVisualStyleBackColor = false;
            this.body.Click += new System.EventHandler(this.body_Click);
            // 
            // pole4
            // 
            this.pole4.Active = false;
            this.pole4.BackColor = System.Drawing.Color.Transparent;
            this.pole4.BackgroundImage = global::BeldenCableInspection.Properties.Resources.PoleOff_min;
            this.pole4.Location = new System.Drawing.Point(69, 57);
            this.pole4.Margin = new System.Windows.Forms.Padding(0);
            this.pole4.Name = "pole4";
            this.pole4.Number = 4;
            this.pole4.PoleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(107)))), ((int)(((byte)(0)))));
            this.pole4.Size = new System.Drawing.Size(72, 72);
            this.pole4.TabIndex = 4;
            this.pole4.Click += new System.EventHandler(this.pole_Click);
            // 
            // pole3
            // 
            this.pole3.Active = false;
            this.pole3.BackColor = System.Drawing.Color.Transparent;
            this.pole3.BackgroundImage = global::BeldenCableInspection.Properties.Resources.PoleOff_min;
            this.pole3.Location = new System.Drawing.Point(178, 57);
            this.pole3.Margin = new System.Windows.Forms.Padding(0);
            this.pole3.Name = "pole3";
            this.pole3.Number = 3;
            this.pole3.PoleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(107)))), ((int)(((byte)(0)))));
            this.pole3.Size = new System.Drawing.Size(72, 72);
            this.pole3.TabIndex = 5;
            this.pole3.Click += new System.EventHandler(this.pole_Click);
            // 
            // pole5
            // 
            this.pole5.Active = false;
            this.pole5.BackColor = System.Drawing.Color.Transparent;
            this.pole5.BackgroundImage = global::BeldenCableInspection.Properties.Resources.PoleOff_min;
            this.pole5.Location = new System.Drawing.Point(125, 125);
            this.pole5.Margin = new System.Windows.Forms.Padding(0);
            this.pole5.Name = "pole5";
            this.pole5.Number = 5;
            this.pole5.PoleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(107)))), ((int)(((byte)(0)))));
            this.pole5.Size = new System.Drawing.Size(72, 72);
            this.pole5.TabIndex = 6;
            this.pole5.Click += new System.EventHandler(this.pole_Click);
            // 
            // pole1
            // 
            this.pole1.Active = false;
            this.pole1.BackColor = System.Drawing.Color.Transparent;
            this.pole1.BackgroundImage = global::BeldenCableInspection.Properties.Resources.PoleOff_min;
            this.pole1.Location = new System.Drawing.Point(69, 192);
            this.pole1.Margin = new System.Windows.Forms.Padding(0);
            this.pole1.Name = "pole1";
            this.pole1.Number = 1;
            this.pole1.PoleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(107)))), ((int)(((byte)(0)))));
            this.pole1.Size = new System.Drawing.Size(72, 72);
            this.pole1.TabIndex = 7;
            this.pole1.Click += new System.EventHandler(this.pole_Click);
            // 
            // pole2
            // 
            this.pole2.Active = false;
            this.pole2.BackColor = System.Drawing.Color.Transparent;
            this.pole2.BackgroundImage = global::BeldenCableInspection.Properties.Resources.PoleOff_min;
            this.pole2.Location = new System.Drawing.Point(178, 192);
            this.pole2.Margin = new System.Windows.Forms.Padding(0);
            this.pole2.Name = "pole2";
            this.pole2.Number = 2;
            this.pole2.PoleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(107)))), ((int)(((byte)(0)))));
            this.pole2.Size = new System.Drawing.Size(72, 72);
            this.pole2.TabIndex = 8;
            this.pole2.Click += new System.EventHandler(this.pole_Click);
            // 
            // Connector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pole2);
            this.Controls.Add(this.pole1);
            this.Controls.Add(this.pole5);
            this.Controls.Add(this.pole3);
            this.Controls.Add(this.pole4);
            this.Controls.Add(this.body);
            this.Controls.Add(this.ring);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(320, 320);
            this.MinimumSize = new System.Drawing.Size(320, 320);
            this.Name = "Connector";
            this.Size = new System.Drawing.Size(320, 320);
            ((System.ComponentModel.ISupportInitialize)(this.ring)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ring;
        private System.Windows.Forms.Button body;
        private Pole pole4;
        private Pole pole3;
        private Pole pole5;
        private Pole pole1;
        private Pole pole2;
    }
}
