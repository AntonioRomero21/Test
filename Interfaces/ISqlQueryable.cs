using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeldenCableInspection
{
    public interface ISqlQueryable
    {
        string SelectQuery { get; }
        string InsertQuery { get; }
        string UpdateQuery { get; }
        string DeleteQuery { get; }
        string Select();
        string Insert();
        string Update();
        string Delete();
    }
}
