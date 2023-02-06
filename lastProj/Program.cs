using lastProj.Data;
using lastProj.Services;
using Microsoft.EntityFrameworkCore;
using Repository = lastProj.Services.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IRepository, Repository>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<MyContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<MyContext>();
   // ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=HomePage}/{id?}");
});

app.Run();