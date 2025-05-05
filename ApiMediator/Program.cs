using ApiMediator.Application.Command;
using ApiMediator.Application.Features.Products.Commands;
using ApiMediator.Application.Features.Users.Commands;
using ApiMediator.DI;
using ApiMediator.Handler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInjectionDependency(builder.Configuration);
builder.Services.AddExceptionHandler<GloabalExceptionHandler>();
builder.Services.AddProblemDetails();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
    });
}

app.UseExceptionHandler(); 
app.UseHttpsRedirection();


#region Constrollers Users
app.MapGet("/listusers",async (IMediator mediator) 
    => Results.Ok(await mediator.Send(new ListUserCommand()).ConfigureAwait(false))
).WithName("ListUsers");

app.MapGet("/user/{id}", async ( string id, IMediator mediator) 
    => Results.Ok(await mediator.Send(new UserByIdCommand { UserId = id }).ConfigureAwait(false))
).WithName("GetUserById");

app.MapPost("/createuser", async ([FromBody] UserCreateCommand command, IMediator mediator) 
    => Results.Ok(await mediator.Send(command).ConfigureAwait(false))
).WithName("CreateUser");

app.MapDelete("/deleteuser/{id}", async (string id, IMediator mediator) 
    => Results.Ok(await mediator.Send(new UserDeleteCommand { Id = id }).ConfigureAwait(false))
).WithName("DeleteUser");
#endregion

#region Constrollers Products
app.MapGet("/listproducts",async (IMediator mediator) 
    => Results.Ok(await mediator.Send(new ListProductComannd()).ConfigureAwait(false))
).WithName("ListProducts");

app.MapPost("/createproduct", async ([FromBody] ProductCreateCommand command, IMediator mediator) 
    => Results.Ok(await mediator.Send(command).ConfigureAwait(false))
).WithName("CreateProduct");
#endregion

app.Run();