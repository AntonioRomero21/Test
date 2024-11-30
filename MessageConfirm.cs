using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeldenCableInspection
{
    public partial class MessageConfirm : Form
    {
        private IconChar confirmIcon;
        private IconChar cancelIcon;
        private Color confirmIconColor;
        private Color cancelIconColor;
        public event EventHandler OnCancel;
        public event EventHandler OnConfirm;
        public IconChar ConfirmIcon
        {
            get => confirmIcon;
            set
            {
                confirm.IconChar = confirmIcon = value;
            }
        }
        public IconChar CancelIcon
        {
            get => cancelIcon;
            set
            {
                cancel.IconChar = cancelIcon = value;
            }
        }
        public Color ConfirmIconColor
        {
            get => confirmIconColor;
            set
            {
                confirm.IconColor = confirmIconColor = value;
            }
        }
        public Color CancelIconColor
        {
            get => cancelIconColor;
            set
            {
                cancel.IconColor = cancelIconColor = value;
            }
        }
        public String Message
        {
            get => message.Text;
            set
            {
                message.Text = value;
            }
        }
        public MessageConfirm()
        {
            InitializeComponent();
        }
        public MessageConfirm(String Message = "", IconChar ConfirmIcon = IconChar.Check, IconChar CancelIcon = IconChar.Cancel, Color? ConfirmIconColor = null, Color? CancelIconColor = null)
        {
            InitializeComponent();
            this.Message = Message;
            this.ConfirmIconColor = ConfirmIconColor ?? Color.Green;
            this.CancelIconColor = CancelIconColor ?? Color.Red;
            this.ConfirmIcon = ConfirmIcon;
            this.CancelIcon = CancelIcon;
        }
        private void confirm_Click(object sender, EventArgs e) => OnConfirm?.Invoke(this, e);
        private void cancel_Click(object sender, EventArgs e) => OnCancel?.Invoke(this, e);
        #region Flicker fix (DO NOT REMOVE)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        #endregion
    }
}
