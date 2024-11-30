using BeldenCableInspection.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BeldenCableInspection.Views
{
    public partial class FileView : UserControl
    {
        private int panelBorderPixels = 5;
        public String EmployeeNo { get => employeeBox.Text; }
        public String EmployeName { get => employeName.Text; set => employeName.Text = value; }
        public event EventHandler EmployeeChanged;
        public event EventHandler SearchBoxTextChanged;
        public string SearchText { get => searchBox.Text; }
        public FileView() => InitializeComponent();
        
        private void searchBox_TextChanged(object sender, EventArgs e) => SearchBoxTextChanged?.Invoke(sender, e);
        private void employeeBox_TextChanged(object sender, EventArgs e) => EmployeeChanged?.Invoke(sender, e);
        public void SetDataSource(DataTable dataTable) => table.SetDataSource(dataTable);
        public int SelectionIndex() => table.SelectedID();
        private void panelRight_Paint(object sender, PaintEventArgs e) => paint_PanelBorders(sender as Panel, e, Color.Yellow, true, true, true, true);
        private void paint_PanelBorders(Panel panel, PaintEventArgs e, Color color, bool left, bool top, bool right, bool bottom)
        {
            ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                left ? color : Color.Transparent, left ? panelBorderPixels : 0, left ? ButtonBorderStyle.Solid : ButtonBorderStyle.None,
                top ? color : Color.Transparent, top ? panelBorderPixels : 0, top ? ButtonBorderStyle.Solid : ButtonBorderStyle.None,
                right ? color : Color.Transparent, right ? panelBorderPixels : 0, right ? ButtonBorderStyle.Solid : ButtonBorderStyle.None,
                bottom ? color : Color.Transparent, bottom ? panelBorderPixels : 0, bottom ? ButtonBorderStyle.Solid : ButtonBorderStyle.None
            );

        }
        Keyboard keyboard;
        private void toggleKeyboard(object sender, EventArgs e)
        {
            bool keyboardOpen = false;
            foreach (Control control in this.Controls)
            {
                if (control.Name == "Keyboard")
                    keyboardOpen = true;
            }
            Control focus = searchBox;
            if ((sender as Control) == searchBox || (sender as Control) == searchPanel)
                focus = searchBox;
            else if ((sender as Control) == employeeBox || (sender as Control) == employeePanel)
                focus = employeeBox;
            if (!keyboardOpen)
            {
                if (focus != null)
                {
                    keyboard = new Keyboard(focus);
                    keyboard.Dock = DockStyle.Bottom;
                    keyboard.Disposed += new EventHandler((object s, EventArgs ea) =>
                    {
                        if (employeeBox.Text == "")
                            employeeBox.Text = "Enter employe ID.";
                        if (searchBox.Text == "")
                            searchBox.Text = "Enter file name.";
                    });
                }
                this.Controls.Add(keyboard);
            }
            (focus as TextBox).SelectAll();
        }
        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (keyboard != null) keyboard.FocusControl(searchBox);
        }
        private void employeeBox_Enter(object sender, EventArgs e)
        {
            if (keyboard != null) keyboard.FocusControl(employeeBox);
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is Keyboard)
                {
                    panel.Controls.Clear();
                    Table table = new Table();
                    table.Dock = DockStyle.Fill;
                    panel.Controls.Add(table);
                }
            }
        }
    }
}
