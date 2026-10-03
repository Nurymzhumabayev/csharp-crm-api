using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Common;
using Project.Application.Contacts;
using Project.Application.Deals;
using Project.domain;
using Project.Infrastructure.Persistence;
using Project.Infrastructure.Repositories;
using Project.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Project.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(CreateContactCommand).Assembly));
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(CreateDealCommand).Assembly));
builder.Services.AddDbContext<AppDbContext>(option => 
option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddValidatorsFromAssembly(typeof(CreateContactCommand).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(option =>
{
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

         ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
};


});
builder.Services.AddAuthorization();

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IDealRepository, DealRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<TokenProvider>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();
app.MapEndpoints();
app.UseExceptionHandler();

app.Run();
