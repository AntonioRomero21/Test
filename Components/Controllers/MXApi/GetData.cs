using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Text.Json.Serialization;
using static HysonMaintainXOrders.Components.Pages.List_Pages.ListWorkOrder;
using static HysonMaintainXOrders.Components.Pages.View_Pages.ViewWork;
using System.Diagnostics;

public class GetData
{
    public WorkOrderListCursor orderWork { get; set; }
    public Asset getAssset { get; set; }
    public List<WorkOrder> workOrder { get; set; }
    public WorkOrder? workOrders { get; set; }
    public WorkOrderResponse? worKOrders { get; set; }
    public AssetResponse assetResponse { get; set; }
    public ResponseAsset responseAsset { get; set; }
    public UserResponse userResponse { get; set; }
    private List<Asset> asset { get; set; }
    private List<User> users { get; set; }

    private MXApi api = new MXApi();
    private String endPoint;
    public string responseContent = String.Empty;

    public GetData(MXApi api)
    {
        this.api = api;
        this.endPoint = api.baseUrl;
    }
    public async Task<WorkOrder> GetWorkInformation(int id)
    {
        string endPoint = api.baseUrl + "workorders/" + id + "?expand=assignees";
        HttpResponseMessage response = await api.Http.GetAsync(endPoint);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
            worKOrders = JsonSerializer.Deserialize<WorkOrderResponse>(responseContent);
            return workOrders = worKOrders.workOrder;
        }
        else
        {
            await Task.Delay(500);
            responseContent = await response.Content.ReadAsStringAsync();
        }
        return null;
    }
    /*
    public async Task<List<WorkOrder>> RepeatabilityWorkOrder(int id)
    {
        endPoint = api.baseUrl + "workorders?assets=" + id;
        HttpResponseMessage response = await api.Http.GetAsync(endPoint);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
            orderWork = JsonSerializer.Deserialize<WorkOrderListCursor>(responseContent);
            workOrder = orderWork.workOrders;
            return workOrder;
        }
        else
        {
            await Task.Delay(500);
            responseContent = await response.Content.ReadAsStringAsync();
        }
        return null;
    }
     */
    public async Task<Boolean> AssetHasWorkOrder(Asset asset) => await AssetHasWorkOrder(asset.id);
    public async Task<Boolean> AssetHasWorkOrder(Int32 assetID)
    {
        endPoint = api.baseUrl + "workorders?assets=" + assetID + "&statuses=OPEN&statuses=IN_PROGRESS";
        HttpResponseMessage response = await api.Http.GetAsync(endPoint);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
            WorkOrderListCursor? workOrders = JsonSerializer.Deserialize<WorkOrderListCursor>(responseContent);
            if (workOrders is null)
            {
                Debug.WriteLine("AssetHasWorkOrder(Asset asset): Serialization is null");
                return true;
            }
            return workOrders.workOrders.Count > 0;
        }
        return true;
    }
    public async Task<List<WorkOrder>> GetWorkAsync()
    {
        endPoint = api.baseUrl + "workorders?expand=assignees";
        endPoint = api.baseUrl + "workorders?expand=extra_fields&expand=assignees";
        HttpResponseMessage response = await api.Http.GetAsync(endPoint);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
            orderWork = JsonSerializer.Deserialize<WorkOrderListCursor>(responseContent);
            workOrder = orderWork.workOrders;
            return workOrder;
        }
        else
        {
            await Task.Delay(500);
            responseContent = await response.Content.ReadAsStringAsync();
        }
        return null;
    }
    public async Task<List<User>> GetUsersAsync()
    {
        endPoint = api.baseUrl + "users";
        HttpResponseMessage response = await api.Http.GetAsync(endPoint);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
            userResponse = JsonSerializer.Deserialize<UserResponse>(responseContent);
            users = userResponse.users;
            return users;
        }
        else
        {
            await Task.Delay(500);
            responseContent = await response.Content.ReadAsStringAsync();
        }
        return null;
    }
    public async Task<User> GetUserAsync(int id)
    {
        User user = new User();
        endPoint = api.baseUrl + "users/" + id;
        HttpResponseMessage response = await api.Http.GetAsync(endPoint);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
            user = JsonSerializer.Deserialize<User>(responseContent);
            return user;
        }
        else
        {
            await Task.Delay(500);
            responseContent = await response.Content.ReadAsStringAsync();
        }
        return null;
    }

    public async Task<List<Asset>> GetAssetsAsync()
    {
        endPoint = api.baseUrl + "assets";
        HttpResponseMessage response = await api.Http.GetAsync(endPoint);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
            assetResponse = JsonSerializer.Deserialize<AssetResponse>(responseContent);
            asset = assetResponse.assets;
            return asset;
        }
        else
        {
            await Task.Delay(500);
            responseContent = await response.Content.ReadAsStringAsync();
        }
        return null;
    }
    public async Task<Asset> GetInformationAsset(int id)
    {
        string endPoint = api.baseUrl + "assets/" + id;
        HttpResponseMessage response = await api.Http.GetAsync(endPoint);
        if (response.IsSuccessStatusCode)
        {
            responseContent = await response.Content.ReadAsStringAsync();
            responseAsset = JsonSerializer.Deserialize<ResponseAsset>(responseContent);
            getAssset = responseAsset.asset;
            return getAssset;
        }
        else
        {
            await Task.Delay(500);
            responseContent = await response.Content.ReadAsStringAsync();
        }
        return null;
    }
}
