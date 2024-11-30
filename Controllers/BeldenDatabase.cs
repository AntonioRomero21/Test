using BeldenCableInspection.Abstracts;
using BeldenCableInspection.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static BeldenCableInspection.Views.Testing;

namespace BeldenCableInspection.Controllers
{
    internal class BeldenDatabase : ASqlDatabase
    {
        public BeldenDatabase(string connectionString) => this.connectionString = connectionString;
        public async Task<DataTable> Select(ISqlQueryable queryable) => await Reader(queryable.Select());
        public async Task<int> Insert(ISqlQueryable queryable) => await Query(queryable.Insert());
        public async Task<int> Insert(ISqlQueryable queryable, QueryReturn queryReturn, TransactionType transaction) => await Query(queryable.Insert(), queryReturn, transaction);
        public async Task Update(ISqlQueryable queryable) => await Query(queryable.Update());
        public async Task Delete(ISqlQueryable queryable) => await Query(queryable.Delete());
        internal async Task<File> GetFile(int id)
        {

            File file = new File();
            file.ID = id;
            DataTable fileDt = await Select(file);
            DataRow fileRow = fileDt.Rows[0];
            //FILE
            file.ID = fileRow.Field<int>("ID");
            file.Name = fileRow.Field<string>("Name");
            file.Date = fileRow.Field<DateTime>("Date");
            string query = String.Format(@"USE [BeldenValitacion] SELECT cc.* FROM [Files] f LEFT JOIN ConnectorConfigs cc ON cc.[File] = f.ID WHERE f.ID = {0}", id);
            DataTable connectorConfigDT = await Reader(query);
            file.ConnectorConfigs = new List<ConnectorConfig>();
            foreach (DataRow connectorConfigRow in connectorConfigDT.Rows)
            {
                ConnectorConfig connectorConfig = new ConnectorConfig();
                connectorConfig.ID = connectorConfigRow.Field<int>("ID");
                connectorConfig.File = file;
                connectorConfig.Side = (Side)Enum.Parse(typeof(Side), connectorConfigRow.Field<string>("Side"));
                connectorConfig.ConnectorType = (ConnectorType)Enum.Parse(typeof(ConnectorType), connectorConfigRow.Field<string>("ConnectorType"));
                connectorConfig.Config = connectorConfigRow.Field<string>("Poles").Split(',').Select(Int32.Parse).ToArray<int>();
                file.AddConnectorConfig(connectorConfig);
            }
            query = String.Format(@"USE [BeldenValitacion] SELECT f.ID, t.ID TestID,w.ID WireID, f.*, t.*,w.*
FROM [dbo].[Files] f 
LEFT JOIN [dbo].[Tests] t ON f.[ID] = t.[File]  
LEFT JOIN [dbo].[Wire] w ON t.[Wire] = w.[ID]
WHERE f.[ID] = {0}", id);
            DataTable testJoinStepDt = await Reader(query);
            file.Tests = new List<Test>();

            foreach (DataRow testStepRow in testJoinStepDt.Rows)
            {
                Test test = new Test();
                //Creating Test
                test.ID = testStepRow.Field<int>("TestID");
                test.File = file;
                test.TestOption = (TestOption)Enum.Parse(typeof(TestOption), testStepRow.Field<string>("TestOption"));

                Wire wire = new Wire();
                wire.ID = testStepRow.Field<int>("WireID");
                test.Wire = wire;
                wire.WireColor = (WireColor)Enum.Parse(typeof(WireColor), testStepRow.Field<string>("WireColor"));
                wire.ProgID = testStepRow.Field<int>("Program");
                wire.PosCam = testStepRow.Field<int>("PosCam");
                wire.PosWire = testStepRow.Field<int>("PosWire");
                //Add Test to File 
                file.Tests.Add(test);
            }

            return file;

        }
        internal async Task InsertFile(File file)
        {
            try
            {
                int fileID = await Insert(file, QueryReturn.SCOPEIDENTITY, TransactionType.NONE);
                file.ID = fileID;
                foreach (ConnectorConfig connector in file.ConnectorConfigs)
                {
                    connector.File = file;
                    int connectorID = await Insert(connector, QueryReturn.SCOPEIDENTITY, TransactionType.NONE);
                    connector.ID = connectorID;
                }
                foreach (Test test in file.Tests)
                {
                    Wire wire;
                    test.File = file;
                    wire = test.Wire;
                    int wireID = await Insert(wire, QueryReturn.SCOPEIDENTITY, TransactionType.NONE);
                    wire.ID = wireID;
                    test.Wire.ID = wireID;
                    int testID = await Insert(test, QueryReturn.SCOPEIDENTITY, TransactionType.NONE);
                    test.ID = testID;
                }
            }
            catch (Exception ex)
            {
                var logger = new ErrorLogger();
                logger.LogError(ex.Message, ex);
                ErrorHandler.AutoRestart = true;
                ErrorHandler.HandlerError(ex);
            }
        }
        internal async Task UpdateFile(File file)
        {
            try
            {
                await Update(file);
                Collection<int> connectorIDs = new Collection<int>();
                foreach (ConnectorConfig connector in file.ConnectorConfigs)
                {
                    connector.File = file;
                    if (connector.ID == 0) connector.ID = await Insert(connector, QueryReturn.SCOPEIDENTITY, TransactionType.NONE); //agregar conector nuevo
                    else await Update(connector); //actualizar el conector
                    connectorIDs.Add(connector.ID);
                }
                if (connectorIDs.Count == 0)
                    await Query(String.Format("USE BeldenValitacion DELETE FROM dbo.ConnectorConfigs WHERE [File] = {0}", String.Join(",", file.ID)));
                else
                    await Query(String.Format("USE BeldenValitacion DELETE FROM dbo.ConnectorConfigs WHERE [ID] NOT IN ({0}) AND [File] = {1}", String.Join(",", connectorIDs), file.ID));
            
                Collection<int> testIDs = new Collection<int>();
                foreach (Test test in file.Tests)
                {
                    test.File = file;
                    if (test.Wire.ID == 0) test.Wire.ID = await Insert(test.Wire, QueryReturn.SCOPEIDENTITY, TransactionType.NONE);
                        else await Update(test.Wire);
                    if (test.ID == 0) test.ID = await Insert(test, QueryReturn.SCOPEIDENTITY, TransactionType.NONE);
                    else await Update(test);
                    testIDs.Add(test.ID);
                }
                if (testIDs.Count == 0) //remove tests because not added
                    await Query(String.Format("USE BeldenValitacion DELETE FROM dbo.Tests WHERE [File] = {0}", String.Join(",", file.ID)));
                else
                    await Query(String.Format("USE BeldenValitacion DELETE FROM dbo.Tests WHERE [ID] NOT IN ({0}) AND [File]  = {1}", String.Join(",", testIDs), file.ID));
            }
            catch (Exception ex)
            {
                var logger = new ErrorLogger();
                logger.LogError(ex.Message, ex);
                ErrorHandler.AutoRestart = true;
                ErrorHandler.HandlerError(ex);
            }
        }
        internal async void SaveResult(object sender, SaveResultsEventArgs e)
        {
            try
            {
                string insertResults = @"USE [BeldenValitacion] INSERT INTO [dbo].[Results] ([UserNumber],[UserName],[FileName],[WireLabel]) OUTPUT INSERTED.ID VALUES ('{0}','{1}','{2}','{3}')";
                insertResults = String.Format(insertResults, e.Result.UserNumber, e.Result.UserName, e.Result.FileName, e.Result.WireLabel);
                Console.WriteLine(insertResults);
                //get the resultsID 
                int resultsID = (await Reader(insertResults)).Rows[0].Field<int>("ID");
                Console.WriteLine(resultsID);
                foreach (ResultWireColor rwColor in e.Result.ResultWire)
                {
                    string insertResultWire = @"USE [BeldenValitacion] INSERT INTO [dbo].[ResultWireColor] ([WireLabelID],[Wire],[WireColor],[Status]) OUTPUT INSERTED.ID VALUES ('{0}','{1}','{2}','{3}')";
                    insertResultWire = String.Format(insertResultWire, e.Result.WireLabel, rwColor.Wire, rwColor.WireColor, rwColor.Status);
                    Console.WriteLine(insertResultWire);
                    int id = await Query(insertResultWire);
                }

            }
            catch (Exception ex)
            {
                var logger = new ErrorLogger();
                logger.LogError(ex.Message, ex);
                ErrorHandler.AutoRestart = true;
                ErrorHandler.HandlerError(ex);
            }
        }
        internal async Task<bool> DeleteFile(int fileID)
        {
           
                File file = await GetFile(fileID);
                String query = String.Format(@" USE [BeldenValitacion] DELETE cc FROM [Files] f LEFT JOIN [Tests] t ON t.[File] = f.[ID] LEFT JOIN [ConnectorConfigs] cc
    ON cc.[File] = f.[ID]  LEFT JOIN [Wire] w
    ON t.[Wire] = w.[ID] 
    WHERE f.[ID] = {0} USE [BeldenValitacion] DELETE w FROM [Files] f LEFT JOIN [Tests] t ON t.[File] = f.[ID] LEFT JOIN [ConnectorConfigs] cc
    ON cc.[File] = f.[ID]  LEFT JOIN [Wire] w
    ON t.[Wire] = w.[ID] 
    WHERE f.[ID] = {0} USE [BeldenValitacion] DELETE t FROM [Files] f LEFT JOIN [Tests] t ON t.[File] = f.[ID] LEFT JOIN [ConnectorConfigs] cc
    ON cc.[File] = f.[ID]  LEFT JOIN [Wire] w
    ON t.[Wire] = w.[ID] 
    WHERE f.[ID] = {0} USE [BeldenValitacion] DELETE f FROM [Files] f LEFT JOIN [Tests] t ON t.[File] = f.[ID] LEFT JOIN [ConnectorConfigs] cc
    ON cc.[File] = f.[ID]  LEFT JOIN [Wire] w
    ON t.[Wire] = w.[ID] 
    WHERE f.[ID] = {0}", fileID);
                int status = await Query(query);
                return status > 0;            
            
        }
        internal async Task<File> CopyFile(int fileID)
        {
            File file = await GetFile(fileID);
            await InsertFile(file);
            return file;
        }
    } 
}
