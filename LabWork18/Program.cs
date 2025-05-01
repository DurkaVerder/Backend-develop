using Prometheus;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();


app.UseHttpMetrics();

app.UseStaticFiles(); 
app.UseAuthorization(); 


app.UseEndpoints(endpoints =>
{
    endpoints.MapMetrics();                     
    endpoints.MapDefaultControllerRoute();  
});

app.Run();
