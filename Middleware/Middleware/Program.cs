using System.IO;
using testexamples.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();




//middleware1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("From Middleware 1\n ");
    await next(context); 

 });

//middleware2
//app.UseMiddleware<MyCustomMiddleware>();
// app.UseCustomMiddleware();
app.UseHelloCustomMiddleware();

//middleware3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("From Middleware 3\n ");
});

app.Run();
