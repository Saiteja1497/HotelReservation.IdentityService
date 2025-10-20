using IdentityService.API.Middlewares;
using IdentityService.Core;
using IdentityService.Core.Mappers;
using IdentityService.Infrastructure;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(cfg => { }, typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddFluentValidationAutoValidation();


var app = builder.Build();
app.UseExceptionHandlingMiddleware();
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();



app.Run();
