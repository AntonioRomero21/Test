
public class WorkOrderResponse
{
    public WorkOrder workOrder { get; set; }
}
public class WorkOrderListCursor
{
    public List<WorkOrder> workOrders { get; set; }
    public String? nextCursor { get; set; }
    public String? nextPageUrl { get; set; }
}
public class Status
{
    public String status { get; set; }
}

public class WorkOrder
{
    public Int32 id { get; set; }
    public Int32 sequentialId { get; set; }
    public Int32? assetId { get; set; }
    public List<Assignees>? assignees { get; set; } = new();
    public List<Object>? attachments { get; set; }
    public List<string>? categories { get; set; } = new();
    public DateTime? completedAt { get; set; }
    public Int32? completerId { get; set; }
    public DateTime createdAt { get; set; } // Added
    public Int32? creatorId { get; set; }
    public DateTime? deletedAt { get; set; }
    public String? description { get; set; }
    public DateTime? dueDate { get; set; } // Added
    public Boolean dueDateIsFullDay { get; set; } // Added
    public Int32? estimatedTime { get; set; }
    public Object? externalData { get; set; }
    public Object? procedure { get; set; }
    public ExtraFields extraFields { get; set; } = new();
    public Int32? locationId { get; set; }
    public Int32? nextId { get; set; }
    public Int32? organizationId { get; set; }
    public Int32? previousId { get; set; }
    public String? priority { get; set; }
    public Int32? requesterId { get; set; }
    public DateTime? startDate { get; set; }
    public String status { get; set; } = String.Empty;
    public String title { get; set; } = String.Empty;
    public List<Object>? teamIds { get; set; }
    public List<Object> partsUsed { get; set; } = new();
    public DateTime? updatedAt { get; set; } // Added
    public List<Int32>? vendorIds { get; set; } = new();
   
    //public Boolean skipRestHook { get; set; } // Added
    //public Int32? procedureTemplateId { get; set; }
    //public Object? repeatability { get; set; }
    //public Int32? workOrderTemplateId { get; set; }
    //public Int32? workRequestId { get; set; }
}

public class RootObject
{
    public List<Assignees> assignees { get; set; }
    public String? priority { get; set; }
}
public class Assignees
{
    public String type { get; set; }
    public Int32? id { get; set; }
}

public class Repeatability
{
    public String _type = String.Empty;
    public Repeatability(String type) => this._type = type;
}
public class Daily : Repeatability
{
    public String type { get => base._type; set => base._type = value; }
    public Daily() : base(Types.DAILY.ToString()) { }
}
public class Weekly : Repeatability
{
    public String type { get => base._type; set => base._type = value; }
    public Int32 _interval;
    public Int32 interval { get => _interval; set => _interval = value; }
    public String[] _days;
    public String[] days { get => _days; set => _days = value; }
    public Weekly() : base(Types.WEEKLY.ToString())
    {
        _interval = 1;
        _days = new String[] { Days.MONDAY.ToString(), Days.WEDNESDAY.ToString(), Days.FRIDAY.ToString() };
    }
}
public class Periodically : Repeatability
{
    public String type { get => base._type; set => base._type = value; }
    public Int32 _interval;
    public Int32 interval { get => _interval; set => _interval = value; }
    public Periodically(Int32 interval = 0) : base(Types.PERIODICALLY.ToString())
    {
        _interval = interval;
    }
}

public class WorkOrderWrapper
{
    public WorkOrder workOrders { get; set; }
    public string Notification { get; set; }
}

public class WorkOrderUtilities
{
    public Config config { get; set; }
    public UrgencyLevel GetUrgencyLevel(TimeSpan timeOpen,int reapeatabilitys)
    {
        var urgencyLevels = config.UrgencyLevels;
        var repeatability = config.Repeatability;

        int totalMinutes = (int)timeOpen.TotalMinutes;
        int totalReapWO = (repeatability.Time.Hours * 60);

        if (reapeatabilitys >= repeatability.RepeatabilityCount && totalMinutes < totalReapWO) 
            return UrgencyLevel.Gray;
        if (totalMinutes > urgencyLevels.NotAssig_WO.Minutes)
            return UrgencyLevel.Red;
        else if (totalMinutes >= urgencyLevels.Unattended_WO.Minutes2) 
            return UrgencyLevel.Orange;
        else if (totalMinutes >= urgencyLevels.Unattended_WO.Minutes1 && totalMinutes < urgencyLevels.Unattended_WO.Minutes2) 
            return UrgencyLevel.Yellow;
        else
            return UrgencyLevel.None;
    }

    public static string GetNotificationColor(UrgencyLevel urgencyLevel)
    {
        switch (urgencyLevel)
        {
            case UrgencyLevel.Gray:
                return "background-color: gray;";
            case UrgencyLevel.Yellow:
                return "background-color: yellow;";
            case UrgencyLevel.Orange:
                return "background-color: orange;";
            case UrgencyLevel.Red:
                return "background-color: red;";
            default:
                return "";
        }
    }
}
public class WorkOrderr
{
    public Int32 id { get; set; }
    public DateTime createdAt { get; set; } // Added
    public String status { get; set; }
    public String title { get; set; }
    public DateTime? updatedAt { get; set; } // Added

}
public class ExtraFields
{
    public String Comments { get; set; } = String.Empty;
    public String Actions { get; set; } = String.Empty;
    public String FailMode { get; set; } = String.Empty;
    public String FailCode { get; set; } = String.Empty;
    public String RequesterUserID { get; set; } = String.Empty;
    public String AssignedUserID { get; set; } = String.Empty;
    public DateTime AssignedTimeStamp { get; set; } = new();
    public String AttendUserID { get; set; } = String.Empty;
    public DateTime AttendTimeStamp { get; set; } = new();
    public String RepairUserID { get; set; } = String.Empty;
    public DateTime CloseTimeStamp { get; set; } = new();
}
