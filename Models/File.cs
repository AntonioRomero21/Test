using BeldenCableInspection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BeldenCableInspection
{
    public class File : ISqlQueryable
    {
        private int id;
        private string name;
        private DateTime date;
        private List<Test> tests;
        private List<ConnectorConfig> connectorConfigs;
        public File() { connectorConfigs = new List<ConnectorConfig>(); }

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Date { get => date; set => date = value; }
        public List<Test> Tests { get => tests; set => tests = value; }

        public void AddTest(Test test)
        {
            tests.Add(test);
            List<Test> sorted = tests.OrderBy(o => o.TestOption).ToList();
            tests = sorted;
        }
        public void AddConnectorConfig(ConnectorConfig connectorConfig)
        {
            if (connectorConfigs.Find(c => c.Side == connectorConfig.Side) is null)
            {
                //add new config
                connectorConfigs.Add(connectorConfig);
            }
            else
            {
                //update config and drop files and steps
                connectorConfigs.Find(c => c.Side == connectorConfig.Side).Config = connectorConfig.Config;
            }
            List<ConnectorConfig> sorted = connectorConfigs.OrderBy(o => o.Side).ToList();
            connectorConfigs = sorted;
        }
        public List<ConnectorConfig> ConnectorConfigs { get => connectorConfigs; set => connectorConfigs = value; }
        public new String ToString()
        {
            string testsStr = String.Empty; 
            testsStr = String.Format("\nFile\n(ID: {0}, Name: {1}, Datetime: {2})", ID, Name, Date.ToString());
            if (connectorConfigs != null)
                foreach (ConnectorConfig connectorConfig in connectorConfigs)
                    testsStr += "\n\tConnector" + connectorConfig.ToString();
            if (tests != null)
                foreach (Test test in tests) testsStr += test.ToString();
          
            return testsStr;
        }
        public string SelectQuery =>
            @"USE [BeldenValitacion] SELECT [ID], [Name], [Date] FROM [dbo].[Files] WHERE [ID] = {0}";
        public string InsertQuery =>
            @"USE [BeldenValitacion] INSERT INTO [dbo].[Files] ([Name],[Date]) VALUES ('{0}',GETDATE())";
        public string UpdateQuery =>
            @"USE [BeldenValitacion] UPDATE [dbo].[Files] SET [Name] = '{0}',[Date] = GETDATE() WHERE [ID] = {1}";
        public string DeleteQuery =>
            @"USE [BeldenValitacion] DELETE FROM [dbo].[Files] WHERE [ID] = {0}";
        public string Select() => String.Format(SelectQuery, this.id);
        public string Insert() => String.Format(InsertQuery, this.name);
        public string Update() => String.Format(UpdateQuery, this.name, id);
        public string Delete() => String.Format(DeleteQuery, this.id);
    }
}
