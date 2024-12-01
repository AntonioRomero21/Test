public class User
{
    public Int32 id { get; set; }
    public String firstName { get; set; }
    public String lastName { get; set; }
    public String email { get; set; }
    public String phoneNumber { get; set; }
    public String authType { get; set; }   
    public DateTime? hourlyRate { get; set; }
    
}

public class UserResponse
{
    public List<User> users { get; set; }
    public String? nextCursor { get; set; }
    public String? nextPageUrl { get; set; }
}