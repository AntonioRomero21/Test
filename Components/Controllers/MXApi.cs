public class MXApi
{
    public string baseUrl = "https://api.getmaintainx.com/v1/";
    private string token = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOjcwMjczNiwib3JnYW5pemF0aW9uSWQiOjI4NTIyMiwiaWF0IjoxNzIxMjYwNzY5LCJzdWIiOiJSRVNUX0FQSV9BVVRIIiwianRpIjoiODkyYTZiOTItMTdhNi00NDhjLWJiMGYtOTNlN2NjNzlmNjlkIn0.z4NGfW06nDeWRjtGIBqmrqe2Gn7XCeDdTaRDn1AH-eQ";
    public HttpClient Http = new HttpClient();

    public MXApi()
    {
        Http.DefaultRequestHeaders.Add("Authorization", token);
    }
}
