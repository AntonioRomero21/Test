using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeldenCableInspection
{
    public enum QueryReturn { STATUS, SCOPEIDENTITY }
    public enum ConnectorSelection { Single, Multiple }
    public enum TransactionType { NONE, COMMIT, ROLLBACK }
    public enum EmergencySource { EmergencyStop }
    public enum ConnectorType { Male, Female }
    public enum Side { A, B }
    public enum TestOption { TwoColor, ThreeColor, FourColor, FiveColor, NONE}
    public enum WireColor { Brown, Black, Blue, White, Green, NONE}

}
