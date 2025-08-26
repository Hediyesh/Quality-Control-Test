//string connectionString = @"Data Source=DESKTOP-J5I16DB; Initial Catalog=ControlDB; Integrated Security=True";
using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlPersistence.Contexts;
using Microsoft.EntityFrameworkCore;
using ControlService.ControlApplication;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("msControlDB")));

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddApplicationServices();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddTransient<CategorySeeder>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

//Identity middleware
app.UseAuthentication();
app.UseAuthorization();
//app.MapStaticAssets();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Products}/{action=GetAllProducts}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapControllers();
app.Run();
