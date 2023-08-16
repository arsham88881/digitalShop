using digitalShop.Persistence.contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Drawing.Text;
using digitalShop.application.Interfaces;
using digitalShop.application.Services.Users.Queries.getUser;
using Microsoft.Data.SqlClient;
using digitalShop.application.Services.Users.Queries.getRole;
using digitalShop.application.Services.Users.Commands.RegesterUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
string connection = @"Data Source = ARSHAM_DESKTOP\NSQLSERVER; Initial catalog = DigitalShopDB; TrustServerCertificate=True; User Id= sa;Password=1234;";
builder.Services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection)); //database context

builder.Services.AddScoped<Igetuserlistservice, getuserlistservice>();
builder.Services.AddScoped<IRigesterUserService, RigesterUserService>();
builder.Services.AddScoped<IgetRolesService, GetRolesService>();


/////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.Run();
