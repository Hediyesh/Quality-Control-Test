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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("msControlDB")));

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();

builder.Services.AddSignalR();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddApplicationServices();

// 🔹 JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "MyUserService",   // باید همون چیزی باشه که تو UserService تولید می‌کنی
            ValidAudience = "MyClients",     // باید با Audience توکن یکی باشه
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("mysupersecurekeythatishardtoguess123"))
        };

        // 🔹 مهم برای SignalR
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) &&
                    path.StartsWithSegments("/hubs/qualitycontrol"))
                {
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });

// 🔹 CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient", policy =>
    {
        policy.WithOrigins("http://localhost:5248", "http://localhost:3003")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowClient");

app.UseRouting();
app.UseAuthentication();   // 🔹 باید قبل از Authorization بیاد
app.UseAuthorization();

app.MapControllers();
app.MapHub<QualityControlHub>("/hubs/qualitycontrol");

app.Run();
