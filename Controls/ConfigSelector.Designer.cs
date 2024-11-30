namespace BeldenCableInspection.Controls
{
    partial class ConfigSelector
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
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.config10 = new BeldenCableInspection.Controls.Config();
            this.config9 = new BeldenCableInspection.Controls.Config();
            this.config8 = new BeldenCableInspection.Controls.Config();
            this.config7 = new BeldenCableInspection.Controls.Config();
            this.config6 = new BeldenCableInspection.Controls.Config();
            this.config5 = new BeldenCableInspection.Controls.Config();
            this.config4 = new BeldenCableInspection.Controls.Config();
            this.config3 = new BeldenCableInspection.Controls.Config();
            this.config2 = new BeldenCableInspection.Controls.Config();
            this.config1 = new BeldenCableInspection.Controls.Config();
            this.downButton = new FontAwesome.Sharp.IconButton();
            this.upButton = new FontAwesome.Sharp.IconButton();
            this.table.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.ColumnCount = 5;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.Controls.Add(this.config10, 4, 1);
            this.table.Controls.Add(this.config9, 3, 1);
            this.table.Controls.Add(this.config8, 2, 1);
            this.table.Controls.Add(this.config7, 1, 1);
            this.table.Controls.Add(this.config6, 0, 1);
            this.table.Controls.Add(this.config5, 4, 0);
            this.table.Controls.Add(this.config4, 3, 0);
            this.table.Controls.Add(this.config3, 2, 0);
            this.table.Controls.Add(this.config2, 1, 0);
            this.table.Controls.Add(this.config1, 0, 0);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(72, 0);
            this.table.Name = "table";
            this.table.RowCount = 2;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table.Size = new System.Drawing.Size(886, 466);
            this.table.TabIndex = 24;
            // 
            // config10
            // 
            this.config10.BackgroundImage = global::BeldenCableInspection.Properties.Resources.F_2_3_4;
            this.config10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.config10.Location = new System.Drawing.Point(711, 236);
            this.config10.Name = "config10";
            this.config10.Size = new System.Drawing.Size(172, 227);
            this.config10.TabIndex = 9;
            this.config10.Value = "F 2,3,4";
            // 
            // config9
            // 
            this.config9.BackgroundImage = global::BeldenCableInspection.Properties.Resources.M_2_3_4;
            this.config9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.config9.Location = new System.Drawing.Point(534, 236);
            this.config9.Name = "config9";
            this.config9.Size = new System.Drawing.Size(171, 227);
            this.config9.TabIndex = 8;
            this.config9.Value = "F 1,3,4";
            // 
            // config8
            // 
            this.config8.BackgroundImage = global::BeldenCableInspection.Properties.Resources.F_1_2_3;
            this.config8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.config8.Location = new System.Drawing.Point(357, 236);
            this.config8.Name = "config8";
            this.config8.Size = new System.Drawing.Size(171, 227);
            this.config8.TabIndex = 7;
            this.config8.Value = "F 1,2,3";
            // 
            // config7
            // 
            this.config7.BackgroundImage = global::BeldenCableInspection.Properties.Resources.M_1_2_3_4_5;
            this.config7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.config7.Location = new System.Drawing.Point(180, 236);
            this.config7.Name = "config7";
            this.config7.Size = new System.Drawing.Size(171, 227);
            this.config7.TabIndex = 6;
            this.config7.Value = "F 1,2,3,4,5";
            // 
            // config6
            // 
            this.config6.BackgroundImage = global::BeldenCableInspection.Properties.Resources.M_1_2_3_4;
            this.config6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.config6.Location = new System.Drawing.Point(3, 236);
            this.config6.Name = "config6";
            this.config6.Size = new System.Drawing.Size(171, 227);
            this.config6.TabIndex = 5;
            this.config6.Value = "F 1,2,3,4";
            // 
            // config5
            // 
            this.config5.BackgroundImage = global::BeldenCableInspection.Properties.Resources.M_3_4_5;
            this.config5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.config5.Location = new System.Drawing.Point(711, 3);
            this.config5.Name = "config5";
            this.config5.Size = new System.Drawing.Size(172, 227);
            this.config5.TabIndex = 4;
            this.config5.Value = "M 3,4,5";
            // 
            // config4
            // 
            this.config4.BackgroundImage = global::BeldenCableInspection.Properties.Resources.M_2_3_4;
            this.config4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.config4.Location = new System.Drawing.Point(534, 3);
            this.config4.Name = "config4";
            this.config4.Size = new System.Drawing.Size(171, 227);
            this.config4.TabIndex = 3;
            this.config4.Value = "M 2,3,4";
            // 
            // config3
            // 
            this.config3.BackgroundImage = global::BeldenCableInspection.Properties.Resources.M_1_3_4;
            this.config3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.config3.Location = new System.Drawing.Point(357, 3);
            this.config3.Name = "config3";
            this.config3.Size = new System.Drawing.Size(171, 227);
            this.config3.TabIndex = 2;
            this.config3.Value = "M 1,3,4";
            // 
            // config2
            // 
            this.config2.BackgroundImage = global::BeldenCableInspection.Properties.Resources.M_1_2_3_4_5;
            this.config2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.config2.Location = new System.Drawing.Point(180, 3);
            this.config2.Name = "config2";
            this.config2.Size = new System.Drawing.Size(171, 227);
            this.config2.TabIndex = 1;
            this.config2.Value = "M 1,2,3,4,5";
            // 
            // config1
            // 
            this.config1.BackgroundImage = global::BeldenCableInspection.Properties.Resources.M_1_2_3_4;
            this.config1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.config1.Location = new System.Drawing.Point(3, 3);
            this.config1.Name = "config1";
            this.config1.Size = new System.Drawing.Size(171, 227);
            this.config1.TabIndex = 0;
            this.config1.Value = "M 1,2,3,4";
            // 
            // downButton
            // 
            this.downButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(155)))));
            this.downButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.downButton.FlatAppearance.BorderSize = 0;
            this.downButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(155)))));
            this.downButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(155)))));
            this.downButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downButton.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.downButton.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.downButton.IconColor = System.Drawing.Color.White;
            this.downButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.downButton.Location = new System.Drawing.Point(958, 0);
            this.downButton.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(72, 466);
            this.downButton.TabIndex = 23;
            this.downButton.UseVisualStyleBackColor = false;
            this.downButton.Visible = false;
            // 
            // upButton
            // 
            this.upButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(155)))));
            this.upButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.upButton.FlatAppearance.BorderSize = 0;
            this.upButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(155)))));
            this.upButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(155)))));
            this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upButton.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.upButton.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.upButton.IconColor = System.Drawing.Color.White;
            this.upButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.upButton.Location = new System.Drawing.Point(0, 0);
            this.upButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(72, 466);
            this.upButton.TabIndex = 22;
            this.upButton.UseVisualStyleBackColor = false;
            this.upButton.Visible = false;
            // 
            // ConfigSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.table);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.MinimumSize = new System.Drawing.Size(1005, 337);
            this.Name = "ConfigSelector";
            this.Size = new System.Drawing.Size(1030, 466);
            this.table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton upButton;
        private FontAwesome.Sharp.IconButton downButton;
        private System.Windows.Forms.TableLayoutPanel table;
        private Config config1;
        private Config config10;
        private Config config9;
        private Config config8;
        private Config config7;
        private Config config6;
        private Config config5;
        private Config config4;
        private Config config3;
        private Config config2;
    }
}
