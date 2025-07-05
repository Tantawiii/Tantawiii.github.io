var builder = WebApplication.CreateBuilder(args);

// For production, serve React build files from wwwroot
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/build";
});

var app = builder.Build();

// Serve static React files
app.UseStaticFiles();
app.UseSpaStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // no backend endpoints, static-only
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

#if DEBUG
    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
#endif
});

app.Run();