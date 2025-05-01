var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddMemoryCache();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["Redis:ConnectionString"];
    options.InstanceName = "CacheDemo:";
});


builder.Services.AddResponseCaching();
builder.Services.AddOutputCache();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseResponseCaching();
app.UseOutputCache();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
