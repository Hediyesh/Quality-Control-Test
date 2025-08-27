using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Load Ocelot configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

// 🔹 JWT Authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "MyUserService",   // از UserService گرفته شده
            ValidAudience = "MyClients",     // از UserService گرفته شده
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("mysupersecurekeythatishardtoguess123")) // کلید همون
        };
    });
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllOrigins",
//        builder =>
//        {
//            builder.AllowAnyOrigin()
//                   .AllowAnyMethod()
//                   .AllowAnyHeader();
//        });
//});

builder.Services.AddAuthorization();

var app = builder.Build();
//app.UseCors("AllowAllOrigins");

app.UseAuthentication();
app.UseAuthorization();

// 🔹 Start Ocelot
await app.UseOcelot();
app.Run();
