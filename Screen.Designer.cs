namespace BeldenCableInspection
{
    partial class Screen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Screen));
            this.bar = new System.Windows.Forms.Panel();
            this.ButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.delete = new FontAwesome.Sharp.IconButton();
            this.save = new FontAwesome.Sharp.IconButton();
            this.neww = new FontAwesome.Sharp.IconButton();
            this.test = new FontAwesome.Sharp.IconButton();
            this.edit = new FontAwesome.Sharp.IconButton();
            this.next = new FontAwesome.Sharp.IconButton();
            this.back = new FontAwesome.Sharp.IconButton();
            this.home = new FontAwesome.Sharp.IconButton();
            this.loadF = new FontAwesome.Sharp.IconButton();
            this.LoadR = new FontAwesome.Sharp.IconButton();
            this.wireCode = new FontAwesome.Sharp.IconButton();
            this.btnConnection = new FontAwesome.Sharp.IconButton();
            this.copy = new FontAwesome.Sharp.IconButton();
            this.logo = new System.Windows.Forms.Panel();
            this.content = new System.Windows.Forms.Panel();
            this.launcher = new BeldenCableInspection.Views.Launcher();
            this.titleBar = new BeldenCableInspection.Controls.TitleBar();
            this.bar.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.content.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar
            // 
            this.bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(155)))));
            this.bar.Controls.Add(this.ButtonsPanel);
            this.bar.Controls.Add(this.logo);
            this.bar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar.Location = new System.Drawing.Point(0, 641);
            this.bar.Margin = new System.Windows.Forms.Padding(0);
            this.bar.MaximumSize = new System.Drawing.Size(0, 130);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(1386, 130);
            this.bar.TabIndex = 6;
            this.bar.Visible = false;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.delete);
            this.ButtonsPanel.Controls.Add(this.save);
            this.ButtonsPanel.Controls.Add(this.neww);
            this.ButtonsPanel.Controls.Add(this.test);
            this.ButtonsPanel.Controls.Add(this.edit);
            this.ButtonsPanel.Controls.Add(this.next);
            this.ButtonsPanel.Controls.Add(this.back);
            this.ButtonsPanel.Controls.Add(this.home);
            this.ButtonsPanel.Controls.Add(this.loadF);
            this.ButtonsPanel.Controls.Add(this.LoadR);
            this.ButtonsPanel.Controls.Add(this.wireCode);
            this.ButtonsPanel.Controls.Add(this.btnConnection);
            this.ButtonsPanel.Controls.Add(this.copy);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonsPanel.Location = new System.Drawing.Point(200, 0);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(1186, 130);
            this.ButtonsPanel.TabIndex = 10;
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Transparent;
            this.delete.FlatAppearance.BorderSize = 0;
            this.delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.ForeColor = System.Drawing.Color.Transparent;
            this.delete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.delete.IconColor = System.Drawing.Color.White;
            this.delete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.delete.IconSize = 80;
            this.delete.Location = new System.Drawing.Point(1058, 0);
            this.delete.Margin = new System.Windows.Forms.Padding(0);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(128, 150);
            this.delete.TabIndex = 14;
            this.delete.Text = "Delete";
            this.delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Visible = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.Transparent;
            this.save.FlatAppearance.BorderSize = 0;
            this.save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.save.ForeColor = System.Drawing.Color.Transparent;
            this.save.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.save.IconColor = System.Drawing.Color.White;
            this.save.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.save.IconSize = 80;
            this.save.Location = new System.Drawing.Point(930, 0);
            this.save.Margin = new System.Windows.Forms.Padding(0);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(128, 150);
            this.save.TabIndex = 10;
            this.save.Text = "Save";
            this.save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.save.UseVisualStyleBackColor = false;
            this.save.Visible = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // neww
            // 
            this.neww.BackColor = System.Drawing.Color.Transparent;
            this.neww.FlatAppearance.BorderSize = 0;
            this.neww.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.neww.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.neww.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.neww.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.neww.ForeColor = System.Drawing.Color.Transparent;
            this.neww.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.neww.IconColor = System.Drawing.Color.White;
            this.neww.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.neww.IconSize = 80;
            this.neww.Location = new System.Drawing.Point(802, 0);
            this.neww.Margin = new System.Windows.Forms.Padding(0);
            this.neww.Name = "neww";
            this.neww.Size = new System.Drawing.Size(128, 150);
            this.neww.TabIndex = 9;
            this.neww.Text = "New";
            this.neww.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.neww.UseVisualStyleBackColor = false;
            this.neww.Visible = false;
            this.neww.Click += new System.EventHandler(this.neww_Click);
            // 
            // test
            // 
            this.test.BackColor = System.Drawing.Color.Transparent;
            this.test.Enabled = false;
            this.test.FlatAppearance.BorderSize = 0;
            this.test.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.test.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.test.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.test.ForeColor = System.Drawing.Color.Transparent;
            this.test.IconChar = FontAwesome.Sharp.IconChar.Fill;
            this.test.IconColor = System.Drawing.Color.White;
            this.test.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.test.IconSize = 80;
            this.test.Location = new System.Drawing.Point(674, 0);
            this.test.Margin = new System.Windows.Forms.Padding(0);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(128, 150);
            this.test.TabIndex = 8;
            this.test.Text = "Test";
            this.test.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.test.UseVisualStyleBackColor = false;
            this.test.Visible = false;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // edit
            // 
            this.edit.BackColor = System.Drawing.Color.Transparent;
            this.edit.FlatAppearance.BorderSize = 0;
            this.edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.edit.ForeColor = System.Drawing.Color.Transparent;
            this.edit.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
            this.edit.IconColor = System.Drawing.Color.White;
            this.edit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.edit.IconSize = 80;
            this.edit.Location = new System.Drawing.Point(546, 0);
            this.edit.Margin = new System.Windows.Forms.Padding(0);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(128, 150);
            this.edit.TabIndex = 7;
            this.edit.Text = "Edit";
            this.edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.edit.UseVisualStyleBackColor = false;
            this.edit.Visible = false;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // next
            // 
            this.next.BackColor = System.Drawing.Color.Transparent;
            this.next.FlatAppearance.BorderSize = 0;
            this.next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.next.ForeColor = System.Drawing.Color.Transparent;
            this.next.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.next.IconColor = System.Drawing.Color.White;
            this.next.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.next.IconSize = 80;
            this.next.Location = new System.Drawing.Point(418, 0);
            this.next.Margin = new System.Windows.Forms.Padding(0);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(128, 150);
            this.next.TabIndex = 12;
            this.next.Text = "Next";
            this.next.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.next.UseVisualStyleBackColor = false;
            this.next.Visible = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Transparent;
            this.back.FlatAppearance.BorderSize = 0;
            this.back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.back.ForeColor = System.Drawing.Color.Transparent;
            this.back.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.back.IconColor = System.Drawing.Color.White;
            this.back.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.back.IconSize = 80;
            this.back.Location = new System.Drawing.Point(290, 0);
            this.back.Margin = new System.Windows.Forms.Padding(0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(128, 150);
            this.back.TabIndex = 13;
            this.back.Text = "Back";
            this.back.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.back.UseVisualStyleBackColor = false;
            this.back.Visible = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // home
            // 
            this.home.BackColor = System.Drawing.Color.Transparent;
            this.home.FlatAppearance.BorderSize = 0;
            this.home.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.home.ForeColor = System.Drawing.Color.Transparent;
            this.home.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            this.home.IconColor = System.Drawing.Color.White;
            this.home.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.home.IconSize = 80;
            this.home.Location = new System.Drawing.Point(162, 0);
            this.home.Margin = new System.Windows.Forms.Padding(0);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(128, 150);
            this.home.TabIndex = 11;
            this.home.Text = "Home";
            this.home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.home.UseVisualStyleBackColor = false;
            this.home.Visible = false;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // loadF
            // 
            this.loadF.BackColor = System.Drawing.Color.Transparent;
            this.loadF.FlatAppearance.BorderSize = 0;
            this.loadF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.loadF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.loadF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadF.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadF.ForeColor = System.Drawing.Color.Transparent;
            this.loadF.IconChar = FontAwesome.Sharp.IconChar.UpRightFromSquare;
            this.loadF.IconColor = System.Drawing.Color.White;
            this.loadF.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.loadF.IconSize = 80;
            this.loadF.Location = new System.Drawing.Point(34, 0);
            this.loadF.Margin = new System.Windows.Forms.Padding(0);
            this.loadF.Name = "loadF";
            this.loadF.Size = new System.Drawing.Size(128, 150);
            this.loadF.TabIndex = 15;
            this.loadF.Text = "Load";
            this.loadF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.loadF.UseVisualStyleBackColor = false;
            this.loadF.Click += new System.EventHandler(this.loadF_Click);
            // 
            // LoadR
            // 
            this.LoadR.BackColor = System.Drawing.Color.Transparent;
            this.LoadR.FlatAppearance.BorderSize = 0;
            this.LoadR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.LoadR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.LoadR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadR.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.LoadR.ForeColor = System.Drawing.Color.Transparent;
            this.LoadR.IconChar = FontAwesome.Sharp.IconChar.UpRightFromSquare;
            this.LoadR.IconColor = System.Drawing.Color.White;
            this.LoadR.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.LoadR.IconSize = 80;
            this.LoadR.Location = new System.Drawing.Point(1058, 150);
            this.LoadR.Margin = new System.Windows.Forms.Padding(0);
            this.LoadR.Name = "LoadR";
            this.LoadR.Size = new System.Drawing.Size(128, 150);
            this.LoadR.TabIndex = 16;
            this.LoadR.Text = "Load Result";
            this.LoadR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LoadR.UseVisualStyleBackColor = false;
            this.LoadR.Visible = false;
            this.LoadR.Click += new System.EventHandler(this.LoadResult_Click);
            // 
            // wireCode
            // 
            this.wireCode.BackColor = System.Drawing.Color.Transparent;
            this.wireCode.FlatAppearance.BorderSize = 0;
            this.wireCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.wireCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.wireCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wireCode.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wireCode.ForeColor = System.Drawing.Color.Transparent;
            this.wireCode.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.wireCode.IconColor = System.Drawing.Color.White;
            this.wireCode.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.wireCode.IconSize = 80;
            this.wireCode.Location = new System.Drawing.Point(930, 150);
            this.wireCode.Margin = new System.Windows.Forms.Padding(0);
            this.wireCode.Name = "wireCode";
            this.wireCode.Size = new System.Drawing.Size(128, 150);
            this.wireCode.TabIndex = 18;
            this.wireCode.Text = "Wire code";
            this.wireCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.wireCode.UseVisualStyleBackColor = false;
            this.wireCode.Visible = false;
            this.wireCode.Click += new System.EventHandler(this.wireCode_Click);
            // 
            // btnConnection
            // 
            this.btnConnection.BackColor = System.Drawing.Color.Transparent;
            this.btnConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnection.FlatAppearance.BorderSize = 0;
            this.btnConnection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnection.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnection.ForeColor = System.Drawing.Color.Transparent;
            this.btnConnection.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnConnection.IconColor = System.Drawing.Color.White;
            this.btnConnection.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConnection.IconSize = 80;
            this.btnConnection.Location = new System.Drawing.Point(802, 153);
            this.btnConnection.Margin = new System.Windows.Forms.Padding(0, 3, 0, 5);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(128, 142);
            this.btnConnection.TabIndex = 19;
            this.btnConnection.Text = "Disconnect";
            this.btnConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConnection.UseVisualStyleBackColor = false;
            this.btnConnection.Visible = false;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // copy
            // 
            this.copy.BackColor = System.Drawing.Color.Transparent;
            this.copy.FlatAppearance.BorderSize = 0;
            this.copy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.copy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copy.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copy.ForeColor = System.Drawing.Color.Transparent;
            this.copy.IconChar = FontAwesome.Sharp.IconChar.Copy;
            this.copy.IconColor = System.Drawing.Color.White;
            this.copy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.copy.IconSize = 80;
            this.copy.Location = new System.Drawing.Point(674, 150);
            this.copy.Margin = new System.Windows.Forms.Padding(0);
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(128, 150);
            this.copy.TabIndex = 20;
            this.copy.Text = "Copy";
            this.copy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.copy.UseVisualStyleBackColor = false;
            this.copy.Visible = false;
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // logo
            // 
            this.logo.BackgroundImage = global::BeldenCableInspection.Properties.Resources.belden_white_logo_v2;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(200, 130);
            this.logo.TabIndex = 0;
            this.logo.Paint += new System.Windows.Forms.PaintEventHandler(this.logo_Paint);
            // 
            // content
            // 
            this.content.BackColor = System.Drawing.Color.Transparent;
            this.content.Controls.Add(this.launcher);
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(0, 72);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(1386, 569);
            this.content.TabIndex = 8;
            // 
            // launcher
            // 
            this.launcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(155)))));
            this.launcher.camera = "192.168.1.36";
            this.launcher.DBHostNameIP = "INSPECTIONTABLE";
            this.launcher.DBUser = "Admin_Cesat";
            this.launcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.launcher.local = "192.168.1.10";
            this.launcher.Location = new System.Drawing.Point(0, 0);
            this.launcher.Name = "launcher";
            this.launcher.Size = new System.Drawing.Size(1386, 569);
            this.launcher.TabIndex = 7;
            this.launcher.UserPassword = "1122";
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(155)))));
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Margin = new System.Windows.Forms.Padding(0);
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 72);
            this.titleBar.MinimumSize = new System.Drawing.Size(1280, 72);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(1386, 72);
            this.titleBar.TabIndex = 5;
            this.titleBar.Version = "0.4.3";
            // 
            // Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 771);
            this.Controls.Add(this.content);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.titleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1278, 670);
            this.Name = "Screen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Belden Products Tester";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.bar.ResumeLayout(false);
            this.ButtonsPanel.ResumeLayout(false);
            this.content.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TitleBar titleBar;
        private System.Windows.Forms.Panel bar;
        private System.Windows.Forms.FlowLayoutPanel ButtonsPanel;
        private FontAwesome.Sharp.IconButton back;
        private FontAwesome.Sharp.IconButton next;
        private FontAwesome.Sharp.IconButton edit;
        private FontAwesome.Sharp.IconButton neww;
        private FontAwesome.Sharp.IconButton delete;
        private FontAwesome.Sharp.IconButton save;
        private FontAwesome.Sharp.IconButton home;
        private FontAwesome.Sharp.IconButton loadF;
        private FontAwesome.Sharp.IconButton LoadR;
        private FontAwesome.Sharp.IconButton wireCode;
        private System.Windows.Forms.Panel logo;
        private Views.Launcher launcher;
        private System.Windows.Forms.Panel content;
        private FontAwesome.Sharp.IconButton test;
        private FontAwesome.Sharp.IconButton btnConnection;
        private FontAwesome.Sharp.IconButton copy;
    }
}