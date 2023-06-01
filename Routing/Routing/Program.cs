using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Routing.CustomConstraints;

var builder = WebApplication.CreateBuilder(new
    WebApplicationOptions());
//{ // <- if want get rest of code, delete braces 
//    WebRootPath = "myroot"
//                                });
//var appTwo = builder.Build();
//appTwo.UseStaticFiles(); //works with the web root
//appTwo.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(
//        Path.Combine(builder.Environment.ContentRootPath + "mywebroot"))
//});

//c:\aspnetcore\StaticFilesExample\StaticFileExample

builder.Services.AddRouting(options =>
    {
        options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
    });
    var app = builder.Build();

    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.Map("files/{filename}.{extension}", async
            context =>
        {
            string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
            string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

            await context.Response.WriteAsync($"In files - {fileName} - {extension}");
        });

        endpoints.Map("employee/profile/{employeeName=harsha}", async
            context =>
        {
            string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
            await context.Response.WriteAsync($"In Employee profile - {employeeName}");
        });

        endpoints.Map("products/details/{id?}", async context =>
        {
            if (context.Request.RouteValues.ContainsKey("id?"))
            {
                int id = Convert.ToInt32(context.Request.RouteValues["id"]);
                await context.Response.WriteAsync($"Products details - {id}");
            }
            else
            {
                await context.Response.WriteAsync($"Products details - id is not supplied");
            }
        });
        //Eg: daily-digest-report/{reportdate}
        endpoints.Map("daily-digest-report/{reportdate:datetime}",
            async context =>
            {
                DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
                await context.Response.WriteAsync($"In daily-digest-report - {reportDate.ToShortDateString()}");
            });

        //Eg: cities/cityid
        endpoints.Map("cities/{cityid:guid}", async context =>
        {
            Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
            await context.Response.WriteAsync($"City information - {cityId}");
        });

        //Eg:sales-report/{year}/{month}
        endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
        {

            int year = Convert.ToInt32(context.Request.RouteValues["year"]);
            string? month = Convert.ToString(context.Request.RouteValues["month"]);
            if (month == "apr" || month == "jul" || month == "oct" ||
            month == "jan")
                await context.Response.WriteAsync($"sales report - {year} - {month}");
            else
            {
                await context.Response.WriteAsync($"{month} is not allowed");
            }
        });
        //Eg: wwwroot
        endpoints.Map("/", async context =>
        {
            await context.Response.WriteAsync("approved");
        });
    });
    app.Run(async context =>
    {
        await context.Response.WriteAsync($" at {context.Request.Path}");

    });
    app.Run();
}
