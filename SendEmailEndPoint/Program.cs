using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SendEmailApplication.Interfaces.Contexts;
//using SendEmailApplication.Services.SendEmail;
//using SendEmailInfrastructure;
using SendEmailPersistence.Contexts;
using SendEmailInfrastructure.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<EmailDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("msEmailDb")));

builder.Services.AddScoped<IEmailDbContext, EmailDbContext>();
builder.Services.AddScoped<ILoginEmailService, LoginEmailService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SendEmailCommandHandler).Assembly));
builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
