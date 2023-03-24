using Confirm.Data;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=index}/{id?}");
app.Run();
