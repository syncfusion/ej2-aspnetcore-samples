#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;
using Syncfusion.Licensing;
using EJ2ScheduleSample.Controllers;
using EJ2SpreadsheetSample.Controllers;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

namespace EJ2CoreSampleBrowser
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "/SyncfusionLicense.txt"))
            {
                string licenseKey = System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "/SyncfusionLicense.txt").Trim();
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
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = null);
            services.AddControllersWithViews();
            services.AddSignalR(e => e.MaximumReceiveMessageSize = int.MaxValue);
            services.AddDirectoryBrowser();
#if REDIS
            services.AddMemoryCache();
            services.AddDistributedRedisCache(option => { option.Configuration = Configuration["ConnectionStrings:Redis"]; });
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ScheduleHub>("/scheduleHub");
                endpoints.MapHub<SpreadsheetHub>("/spreadsheetHub");
            });

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
        }
    }
}
