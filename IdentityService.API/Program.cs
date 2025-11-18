using IdentityService.API.Middlewares;
using IdentityService.Core;
using IdentityService.Core.Mappers;
using IdentityService.Infrastructure;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); 
builder.Services.AddAutoMapper(cfg => { }, typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();
app.UseExceptionHandlingMiddleware();
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();



app.Run();
