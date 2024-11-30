using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeldenCableInspection
{
    public class PoleClickEventArgs: EventArgs
    {
        private int[] poles;
        private int pole;
        public PoleClickEventArgs(int[] poles) => this.poles = poles;
        public PoleClickEventArgs(int pole) => this.pole = pole;
        public int[] Poles { get { return poles; } }
        public int Pole { get => pole; set => pole = value; }
    }
}
