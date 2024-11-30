using BeldenCableInspection.Controls;
using BeldenCableInspection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BeldenCableInspection
{
    public class Test : ISqlQueryable
    {
        private int id;
        private File file;
        private TestOption testOption;
        private Wire wire = new Wire();
        public Test()
        {
            
        }
        public Test(File file, TestOption testOption,Wire wire)
        {
            this.file = file;
            this.testOption = testOption;
            this.wire = wire;
        }
        public int ID { get => id; set => id = value; }
        public File File { get => file; set => file = value; }
        public TestOption TestOption { get => testOption; set => testOption = value; }
        public Wire Wire { get => wire; set => wire = value; }

         public new String ToString() => String.Format("\nTests\n(ID: {0}, File: {1}, TestOption: {2})", ID, File.ID, testOption.ToString());
       
        public string SelectQuery =>
            @"USE [BeldenValitacion] SELECT [ID], [File], [TestOption], [Wire] FROM [dbo].[Tests] WHERE [ID] = {0}";
        public string InsertQuery =>
            @"USE [BeldenValitacion] INSERT INTO [dbo].[Tests] ([File],[TestOption],[Wire]) VALUES ({0},'{1}',{2})";
        public string UpdateQuery =>
            @"USE [BeldenValitacion] UPDATE [dbo].[Tests] SET [File] = {0}, [TestOption] = '{1}',[Wire] = {2} WHERE [ID] = {3}";
        public string DeleteQuery =>
            @"USE [BeldenValitacion] DELETE FROM [dbo].[Tests] WHERE [ID] = {0}";
        public string Select() => String.Format(SelectQuery, id);
        public string Insert() => String.Format(InsertQuery, file.ID, TestOption.ToString(),wire.ID);
        public string Update() => String.Format(UpdateQuery, file.ID, TestOption.ToString(),wire.ID, id);
        public string Delete() => String.Format(DeleteQuery, id);
    }
}
