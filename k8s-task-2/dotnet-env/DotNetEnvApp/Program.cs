using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Force Kestrel to listen on port 80 (all network interfaces, IPv4 & IPv6)
builder.WebHost.UseUrls("http://0.0.0.0:80");

var app = builder.Build();

app.MapGet("/", () =>
{
    var aspnetEnv = builder.Environment.EnvironmentName;
    // var appTitle = Environment.GetEnvironmentVariable("APP_TITLE") ?? "Default Title";
    var appConString = builder.Configuration["Database:ConnectionString"] ?? "Default Version";

    var html =
        "<html>" +
        "<head>" +
        "<title>App Info</title>" +
        "<style>" +
        "body { font-family: Arial, sans-serif; margin: 40px; background: #f9f9f9; color: #333; }" +
        "h1 { color: #444; }" +
        ".box { background: white; padding: 20px; border-radius: 10px; box-shadow: 0 2px 6px rgba(0,0,0,0.1); width: 400px; }" +
        ".item { margin: 10px 0; font-size: 18px; }" +
        ".label { font-weight: bold; }" +
        "</style>" +
        "</head>" +
        "<body>" +
        "<h1>.NET App Environment</h1>" +
        "<div class='box'>" +
        $"<div class='item'><span class='label'>aspnetEnv:</span> {aspnetEnv}</div>" +
        $"<div class='item'><span class='label'>ConnectionString</span> {appConString}</div>" +
        "</div>" +
        "</body>" +
        "</html>";

    return Results.Content(html, "text/html");
});

app.Run();






// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.Hosting;

// var builder = WebApplication.CreateBuilder(args);

// // Listen on port 80
// builder.WebHost.UseUrls("http://0.0.0.0:80");

// // Add environment variables as configuration source
// builder.Configuration.AddEnvironmentVariables();

// var app = builder.Build();

// app.MapGet("/", () =>
// {
//     var aspnetEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? builder.Environment.EnvironmentName;
//     var connectionString = Environment.GetEnvironmentVariable("Database__ConnectionString") ?? "Not Set";

//     var html =
//         "<html>" +
//         "<head>" +
//         "<title>App Info</title>" +
//         "<style>" +
//         "body { font-family: Arial, sans-serif; margin: 40px; background: #f9f9f9; color: #333; }" +
//         "h1 { color: #444; }" +
//         ".box { background: white; padding: 20px; border-radius: 10px; box-shadow: 0 2px 6px rgba(0,0,0,0.1); width: 400px; }" +
//         ".item { margin: 10px 0; font-size: 18px; }" +
//         ".label { font-weight: bold; }" +
//         "</style>" +
//         "</head>" +
//         "<body>" +
//         "<h1>.NET App Environment</h1>" +
//         "<div class='box'>" +
//         $"<div class='item'><span class='label'>ASPNETCORE_ENVIRONMENT:</span> {aspnetEnv}</div>" +
//         $"<div class='item'><span class='label'>Database:ConnectionString:</span> {connectionString}</div>" +
//         "</div>" +
//         "</body>" +
//         "</html>";

//     return Results.Content(html, "text/html");
// });

// app.Run();

