#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using EJ2SpreadsheetSample.Controllers;
using System.Text.RegularExpressions;

if (File.Exists(Directory.GetCurrentDirectory() + "/SyncfusionLicense.txt"))
{
    string licenseKey = File.ReadAllText(Directory.GetCurrentDirectory() + "/SyncfusionLicense.txt").Trim();
    SyncfusionLicenseProvider.RegisterLicense(licenseKey);
    if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/scripts/index.js"))
    {
        string regexPattern = "ej.base.registerLicense(.*);";
        string jsContent = File.ReadAllText(Directory.GetCurrentDirectory() + "/wwwroot/scripts/index.js");
        MatchCollection matchCases = Regex.Matches(jsContent, regexPattern);
        foreach (Match matchCase in matchCases)
        {
            var replaceableString = matchCase.ToString();
            jsContent = jsContent.Replace(replaceableString, "ej.base.registerLicense('" + licenseKey + "');");
        }
        File.WriteAllText(Directory.GetCurrentDirectory() + "/wwwroot/scripts/index.js", jsContent);
    }
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
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#if REDIS
builder.Services.AddMemoryCache();
builder.Services.AddDistributedRedisCache(option => { option.Configuration = builder.Configuration["ConnectionStrings:Redis"]; });
#endif
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
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
    endpoints.MapHub<SpreadsheetHub>("/spreadsheetHub");
});
app.Run();

