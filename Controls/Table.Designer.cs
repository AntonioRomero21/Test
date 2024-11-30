namespace BeldenCableInspection.Controls
{
    partial class Table
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.programs = new System.Windows.Forms.DataGridView();
            this.programsScrollbar = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.programs)).BeginInit();
            this.SuspendLayout();
            // 
            // programs
            // 
            this.programs.AllowUserToAddRows = false;
            this.programs.AllowUserToDeleteRows = false;
            this.programs.AllowUserToResizeColumns = false;
            this.programs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 26.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(107)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.programs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.programs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.programs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.programs.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.programs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.programs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.programs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.programs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 26.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(107)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.programs.DefaultCellStyle = dataGridViewCellStyle3;
            this.programs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programs.EnableHeadersVisualStyles = false;
            this.programs.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.programs.Location = new System.Drawing.Point(0, 0);
            this.programs.Margin = new System.Windows.Forms.Padding(0);
            this.programs.MultiSelect = false;
            this.programs.Name = "programs";
            this.programs.ReadOnly = true;
            this.programs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.programs.RowHeadersVisible = false;
            this.programs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.programs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.programs.Size = new System.Drawing.Size(937, 546);
            this.programs.TabIndex = 22;
            // 
            // programsScrollbar
            // 
            this.programsScrollbar.Dock = System.Windows.Forms.DockStyle.Right;
            this.programsScrollbar.Location = new System.Drawing.Point(873, 0);
            this.programsScrollbar.Name = "programsScrollbar";
            this.programsScrollbar.Size = new System.Drawing.Size(64, 546);
            this.programsScrollbar.TabIndex = 23;
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.programsScrollbar);
            this.Controls.Add(this.programs);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Table";
            this.Size = new System.Drawing.Size(937, 546);
            ((System.ComponentModel.ISupportInitialize)(this.programs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView programs;
        private System.Windows.Forms.VScrollBar programsScrollbar;
    }
}
