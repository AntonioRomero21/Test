using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeldenCableInspection
{
    public class ConnectorConfig : ISqlQueryable
    {
        int id;
        File file;
        Side side;
        ConnectorType connectorType;
        int[] config;
        public ConnectorConfig() { }
        public ConnectorConfig(ConnectorType type, int[] config)
        {
            ConnectorType = type;
            Config = config;

        }
        public int ID { get => id; set => id = value; }
        public File File { get => file; set => file = value; }
        public Side Side { get => side; set => side = value; }
        public ConnectorType ConnectorType { get => connectorType; set => connectorType = value; }
        public int[] Config { get => config; set => config = value; }
        public new string ToString() => String.Format("\n\t(ID: {0}, Side: {1}, Type: {2}, Config: {3})", id, side.ToString(), connectorType.ToString(), String.Join(",", config));
        public string SelectQuery => @"USE [BeldenValitacion] SELECT [ID],[File],[Side],[ConnectorType],[Poles] FROM [dbo].[ConnectorConfigs] WHERE [ID] = {0}";
        public string InsertQuery => @"USE [BeldenValitacion] INSERT INTO [dbo].[ConnectorConfigs] ([File],[Side],[ConnectorType],[Poles]) VALUES ({0},'{1}','{2}','{3}')";
        public string UpdateQuery => @"USE [BeldenValitacion] UPDATE [dbo].[ConnectorConfigs] SET [File] = {0}, [Side] = '{1}', [ConnectorType] = '{2}', [Poles] = '{3}' WHERE [ID] = {4}";
        public string DeleteQuery => @"USE [BeldenValitacion] DELETE FROM [dbo].[ConnectorConfigs] WHERE [ID] = {0}";
        public string Select() => String.Format(SelectQuery, ID);
        public string Insert() => String.Format(InsertQuery, file.ID, side.ToString(), connectorType.ToString(), String.Join(",", Config));
        public string Update() => String.Format(UpdateQuery, file.ID, side.ToString(), connectorType.ToString(), String.Join(",", Config), id);
        public string Delete() => String.Format(DeleteQuery, ID);
    }
}
