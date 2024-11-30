using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeldenCableInspection.Models
{
    public class ProgramIV3 : ISqlQueryable
    {
        int id;
        string ProgName;
        
        public ProgramIV3() { }

        public int ID { get => id; set => id = value; }
        public string NameProg { get => ProgName; set => ProgName = value; }

        public new string ToString() => String.Format("\n\t(ID: {0}, ProgName: {1})", id, ProgName);
        public string SelectQuery => @"USE [BeldenValitacion] SELECT [ID],[ProgName] FROM [dbo].[ProgChanges] WHERE [ID] = {0}";
        public string InsertQuery => @"USE [BeldenValitacion] INSERT INTO [dbo].[ProgChanges] ([ProgName]) VALUES ('{0}')";
        public string UpdateQuery => @"USE [BeldenValitacion] UPDATE [dbo].[ProgChanges] SET ,[ProgName] = '{0}' WHERE [ID] = {1}";
        public string DeleteQuery => @"USE [BeldenValitacion] DELETE FROM [dbo].[ProgChanges] WHERE [ID] = {0}";
        public string Select() => String.Format(SelectQuery, ID);
        public string Insert() => String.Format(InsertQuery, ProgName);
        public string Update() => String.Format(UpdateQuery, ProgName, id);
        public string Delete() => String.Format(DeleteQuery, ID);
    }
}
