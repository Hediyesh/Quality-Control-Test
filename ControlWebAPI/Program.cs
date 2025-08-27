//string connectionString = @"Data Source=DESKTOP-J5I16DB; Initial Catalog=ControlDB; Integrated Security=True";
using ControlApplication.Common.Notifications;
using ControlService.ControlApplication;
using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services.MaintenanceLogs.Commands.AddMaintenanceLogs;
using ControlService.ControlApplication.Services.QualityControlEntries.Commands.AddQualityControlEntry;
using ControlService.ControlPersistence.Contexts;
using ControlWebAPI.Hubs;
using ControlWebAPI.Notifications;
using MediatR;
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

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowClient",
//        policy =>
//        {
//            policy.WithOrigins("http://localhost:5248") // دامنه کلاینت
//                  .AllowAnyHeader()
//                  .AllowAnyMethod()
//                  .AllowCredentials(); // مهم برای SignalR
//        });
//});
builder.Services.AddSignalR();
builder.Services.AddScoped<INotificationService, NotificationService>();
//builder.Services.AddMediatR(typeof(AddQualityControlEntryHandler).Assembly);
builder.Services.AddApplicationServices();

//builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);
// the 3 lines below are used for the client to not send bad request 400, instead we handle in the function in controller
//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressModelStateInvalidFilter = true;
//});

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
// اضافه کردن CORS
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
//app.UseCors("AllowClient");

app.MapHub<QualityControlHub>("/hubs/qualitycontrol");


app.Run();
