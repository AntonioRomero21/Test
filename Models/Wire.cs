using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BeldenCableInspection.Models
{
    public class Wire : ISqlQueryable
    {
        int id;
        WireColor wirecolor;
        int prog;
        int posWire;
        int posCam;
        public Wire() { }
        public Wire(WireColor wirecolor,int prog,int posCam, int posWire) 
        {
            this.wirecolor = wirecolor;
            this.prog = prog;
            this.posWire = posWire;
            this.posCam = posCam;
        }
        public int ID { get => id; set => id = value; }
        public WireColor WireColor { get => wirecolor; set => wirecolor = value; }
        public int ProgID { get => prog; set => prog = value; }
        public int PosCam { get => posCam; set => posCam = value; }
        public int PosWire { get => posWire; set => posWire = value; }        
        public new String ToString() => String.Format("\n\tWire\n\t(ID: {0}, WireColor: {1},PosCam: {2},PosWire: {3})", id, wirecolor.ToString(), ProgID, posCam, posWire); 
      
        public string SelectQuery =>
            @"USE [BeldenValitacion] SELECT [ID], [WireColor], [Program], [PosCam], [PosWire] FROM [dbo].[Wire] WHERE [ID] = {0}";
        public string InsertQuery =>
            @"USE [BeldenValitacion] INSERT INTO [dbo].[Wire] ([WireColor],[Program],[PosCam],[PosWire]) VALUES ('{0}',{1},{2},{3})";
        public string UpdateQuery =>
            @"USE [BeldenValitacion] UPDATE [dbo].[Wire] SET [WireColor] = '{0}',[Program] = {1},[PosCam] = {2},[PosWire] = {3} WHERE [ID] = {4}";
        public string DeleteQuery =>
            @"USE [BeldenValitacion] DELETE FROM [dbo].[Wire] WHERE [ID] = {0}";
        public string Select() => String.Format(SelectQuery, id);
        public string Insert() => String.Format(InsertQuery, WireColor, ProgID, PosCam, PosWire);
        public string Update() => String.Format(UpdateQuery, WireColor, ProgID, PosCam, PosWire, id);
        public string Delete() => String.Format(DeleteQuery, id);

    }
}
