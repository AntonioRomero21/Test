using Microsoft.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

public class PatchData
{
    private MXApi api = new MXApi();
    private String endPoint;
    public string responseContent = String.Empty;
    public PatchData(MXApi api)
    {
        this.api = api;
    }
    
    public async Task SetStatus(Status status, int id)
    {
        endPoint = api.baseUrl + "workorders/" + id + "/status";
        string serialized = JsonSerializer.Serialize(status);
        StringContent content = new StringContent(serialized, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await api.Http.PatchAsync(endPoint, content);

        if (response.IsSuccessStatusCode) responseContent = await response.Content.ReadAsStringAsync();
        else responseContent = await Task.Delay(500).ContinueWith((t) => response.Content.ReadAsStringAsync()).Result;
    }

    public async Task UpdateWorkOrders(StringContent content, int id)
    {
        endPoint = api.baseUrl + "workorders/" + id;

        HttpResponseMessage response = await api.Http.PatchAsync(endPoint, content);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
        }
        else
        {
            await Task.Delay(500);
            responseContent = await response.Content.ReadAsStringAsync();
        }
    }

    public async Task UpdateWorkOrder(WorkOrder wo)
    {
        endPoint = api.baseUrl + "workorders/" + wo.id;
        string serialized = JsonSerializer.Serialize(wo);
        StringContent content = new StringContent(serialized, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await api.Http.PatchAsync(endPoint, content);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
        }
        else
        {
            await Task.Delay(500);
            responseContent = await response.Content.ReadAsStringAsync();
        }
    }
}