var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

Dictionary<int, string> countries = new Dictionary<int, string>()
{
    {1, "United States"},
    {2, "Canada"},
    {3, "United Kingdom"},
    {4, "India"},
    {5, "Japan"}
};

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/countries", async context =>
    {
        foreach (KeyValuePair<int, string> country in countries)
        {
            await context.Response.WriteAsync($"{country.Key} {country.Value}\n");
        }
    });

    //Checks country if it's in the right type and range

    endpoints.MapGet("/countries/{countryID:int:range(1,20)}", async context =>
    {
        if(!context.Request.RouteValues.ContainsKey("countryID") == true)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Bad request" +
                "Wrong CountryID. Should be a type of int and a number between 1-20.");
        }

        int countryId = Convert.ToInt32(context.Request.RouteValues["countryID"]);

        //Checks country if exists in the dictionary

        if (countries.ContainsKey(countryId))
        {
            string countryName = countries[countryId];
            await context.Response.WriteAsync($"{countryName}");
        }
        else
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Not Found 404. \nCountry doesn't exist in the dictionary.");
        }
    });
    endpoints.MapGet("/countries/{countryID:int:min(20)}", async context =>
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Not Found 404. \nOut of range >20");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("No response");
});
app.Run();
