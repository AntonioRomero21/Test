using System.Text.Json;
using System.Text;
using static System.Net.WebRequestMethods;

public class PostData
{
    private WorkOrder workOrders = new WorkOrder();
    //private WorkOrderResponse workOrderResponse = new WorkOrderResponse();
    private Asset assets = new Asset();
    private MXApi api = new MXApi();
    private String endPoint;
    public string responseContent = String.Empty;
    public PostData(MXApi api)
    {
        this.api = api;
        this.endPoint = api.baseUrl;
    }
    public async Task<Boolean> InsertUser(StringContent content)
    {
        Boolean success = false;
        endPoint = endPoint + "users";
        HttpResponseMessage response = await api.Http.PostAsync(endPoint, content);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
            success = true;
        }
        else
        {
            await Task.Delay(500);
            responseContent = await response.Content.ReadAsStringAsync();
            success = false;
            Console.WriteLine(responseContent);
        }

        return success;
    }
    public async Task<Boolean> InsertOrder(StringContent content)
    {
        Boolean success = false;

        endPoint = endPoint + "workorders?skipWebhook=false";
        HttpResponseMessage response = await api.Http.PostAsync(endPoint, content);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
            success = true;
        }
        else
        {
            await Task.Delay(500);
            responseContent = await response.Content.ReadAsStringAsync();
            success = false;
        }
        return success;
    }
    public async Task<Boolean> AddWorkOrder(WorkOrder wo)
    {
        endPoint = endPoint + "workorders?skipWebhook=false";
        string serialized = JsonSerializer.Serialize(wo);
        StringContent content = new StringContent(serialized, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await api.Http.PostAsync(endPoint, content);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
            return true;
        }
        else
        {
            await Task.Delay(500);
            responseContent = await response.Content.ReadAsStringAsync();
            return false;
        }
    }
}