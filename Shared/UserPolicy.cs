namespace HysonMaintainXOrders.Shared
{
    public class UserPolicy
    {
        public const string VIEW_PRODUCT = "VIEW_PRODUCT";
        public const string ADD_PRODUCT = "ADD_PRODUCT";
        public const string EDIT_PRODUCT = "EDIT_PRODUCT";
        public const string DELETE_PRODUCT = "DELETE_PRODUCT";
        public const string CLASE_V = "CLASE_V";
        public const string TECHNICIAN = "TECHNICIAN";
        public const string LEADER = "LEADER";
        public const string SUPERVISOR = "SUPERVISOR";
        public static List<string> GetPolicies()
        {
            return new List<string>
            {
                VIEW_PRODUCT,
                ADD_PRODUCT,
                EDIT_PRODUCT,
                DELETE_PRODUCT,
                CLASE_V,
                TECHNICIAN,
                LEADER,
                SUPERVISOR
            };
        }
    }
}
