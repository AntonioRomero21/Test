using HysonMaintainXOrders.Components;
using HysonMaintainXOrders.Shared;
using HysonMaintainXOrders.Shared.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthorization((authorizationOptions) =>
{
    foreach (String userPolicy in UserPolicy.GetPolicies())
        authorizationOptions.AddPolicy(userPolicy, (AuthorizationPolicyBuilder policyBuilder) => policyBuilder.RequireClaim(userPolicy, "true"));
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<PipesClient>();
builder.Services.AddSingleton<AuthorizationService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie((cookieAuthenticationOptions) => {
        cookieAuthenticationOptions.Cookie.Name = "auth_token";
        cookieAuthenticationOptions.LoginPath = "/login";
        cookieAuthenticationOptions.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        cookieAuthenticationOptions.AccessDeniedPath = "/access-denied";
    });
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddDbContext<AppDbContext>((dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("ServerCesat")));

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();
