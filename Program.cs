using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using Syncfusion.Licensing;
using EJ2ScheduleSample.Controllers;

#if !NET6_0
namespace EJ2CoreSampleBrowser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    webBuilder.CaptureStartupErrors(true);
                    webBuilder.UseSetting("detailedErrors", "true");
                });

    }
}
#else
if (File.Exists(Directory.GetCurrentDirectory() + "/SyncfusionLicense.txt"))
{
    string licenseKey = File.ReadAllText(Directory.GetCurrentDirectory() + "/SyncfusionLicense.txt");
    SyncfusionLicenseProvider.RegisterLicense(licenseKey);
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc()
    .AddNewtonsoftJson(x =>
    {
        x.SerializerSettings.ContractResolver = null;
    });
builder.Services.AddSignalR();
builder.Services.AddDirectoryBrowser();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseBrowserLink();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseFileServer();
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    DefaultContentType = "plain/text",
    FileProvider = new PhysicalFileProvider(
    Path.Combine(Directory.GetCurrentDirectory(), "Controllers")),
    RequestPath = "/Controllers"
});
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    DefaultContentType = "plain/text",
    FileProvider = new PhysicalFileProvider(
    Path.Combine(Directory.GetCurrentDirectory(), "Views")),
    RequestPath = "/Views"
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ScheduleHub>("/scheduleHub");
});
app.Run();
#endif
