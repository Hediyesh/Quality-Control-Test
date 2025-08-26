//string connectionString = @"Data Source=DESKTOP-J5I16DB; Initial Catalog=ControlDB; Integrated Security=True";
using ControlInfrastructure.Configs;
using ControlService.ControlApplication;
using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services.MaintenanceLogs.Commands.AddMaintenanceLogs;
using ControlService.ControlPersistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("msControlDB")));

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddMaintenanceLogCommand).Assembly));

builder.Services.AddApplicationServices();

builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//app.MapStaticAssets();
//app.UseStaticFiles();
app.MapControllers();


app.Run();
