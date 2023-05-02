using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefautConnectionString")));
builder.Services.AddScoped<IActorsService, ActorsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.


AppDbInit.Seed(app);

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
