var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpLogging(options => { });
builder.Services.AddControllers();
var app = builder.Build();
app.UseHttpLogging();
app.MapControllers();
app.UseStaticFiles();
app.UseStatusCodePagesWithRedirects("/not-found");
app.Run();
