namespace HysonMaintainXOrders.Shared
{
    public class UserRoles
    {
        public const string CLASE_V = "CLASE_V";
        public const string TECHNICIAN = "TECHNICIAN";
        public const string LEADER = "LEADER";
        public const string SUPERVISOR = "SUPERVISOR";
        public static List<string> GetRoles()
        {
            return new List<string>
            {
                CLASE_V,
                TECHNICIAN,
                LEADER,
                SUPERVISOR
            };
        }
    }
}
