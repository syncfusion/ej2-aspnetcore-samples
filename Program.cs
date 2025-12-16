#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using EJ2ScheduleSample.Pages;
using EJ2SDiagramSample.Pages;
using Microsoft.Extensions.AI;
using OpenAI;
using Syncfusion.EJ2;
using Syncfusion.EJ2.AI;
#if STAGING
using Azure.AI.OpenAI;
using System.ClientModel;
#endif

using System.Text.RegularExpressions;
using EJ2CoreSampleBrowser.Services;
using StackExchange.Redis;

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
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHsts(options =>
{
    options.MaxAge = TimeSpan.FromDays(730);   // Set max-age to 730 days
    options.IncludeSubDomains = true;           // Include subdomains
    options.Preload = true;                     // Enable preload
});
builder.Services.AddRazorPages();
#region AI Configuration
#if STAGING
/* Azure OpenAI Service */
string AzureApiKey = Environment.GetEnvironmentVariable("API_KEY") ?? "Your-Api-Key";
string AzureDeploymentName = Environment.GetEnvironmentVariable("DEPLOYMENT_NAME") ?? "Your-Model-Name";
string AzureEndpoint = Environment.GetEnvironmentVariable("END_POINT") ?? "https://your-azure-openai.openai.azure.com/";
AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
     new Uri(AzureEndpoint),
     new ApiKeyCredential(AzureApiKey)
);
IChatClient AIChatClient = azureOpenAIClient.GetChatClient(AzureDeploymentName).AsIChatClient();
#else
/* OpenAI Service */
string apiKey = Environment.GetEnvironmentVariable("API_KEY") ?? "Your-Api-Key";
string deploymentName = Environment.GetEnvironmentVariable("DEPLOYMENT_NAME") ?? "Your-Model-Name";

OpenAIClient openAIClient = new OpenAIClient(apiKey);
IChatClient AIChatClient = openAIClient.GetChatClient(deploymentName).AsIChatClient();
#endif
builder.Services.AddChatClient(AIChatClient);
builder.Services.AddScoped<UserTokenService>();
builder.Services.AddScoped<IChatInferenceService, AIService>(sp =>
{
    var userTokenService = sp.GetRequiredService<UserTokenService>();
    return new AIService(userTokenService, AIChatClient);
});
builder.Services.AddScoped<AIService>();
builder.Services.AddSyncfusionSmartComponents();
#endregion

builder.Services.AddMvc()
    .AddNewtonsoftJson(x =>
    {
        x.SerializerSettings.ContractResolver = null;
    });
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
    options.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10MB
    options.MaximumParallelInvocationsPerClient = 2;
    options.KeepAliveInterval = TimeSpan.FromMinutes(5);
    options.ClientTimeoutInterval = TimeSpan.FromHours(24);
    options.HandshakeTimeout = TimeSpan.FromSeconds(30);
})
.AddJsonProtocol(options =>
{
    options.PayloadSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    options.PayloadSerializerOptions.WriteIndented = false;
    options.PayloadSerializerOptions.MaxDepth = 64;
    options.PayloadSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddDirectoryBrowser();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); 
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
#if REDIS
builder.Services.AddMemoryCache();
builder.Services.AddDistributedRedisCache(option => { option.Configuration = builder.Configuration["ConnectionStrings:Redis"]; });
#endif

// Redis and services for Diagram collaboration
builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("Redis") ?? "localhost:6379,abortConnect=false";
    return ConnectionMultiplexer.Connect(connectionString);
});

builder.Services.AddScoped<IRedisService, RedisService>();
builder.Services.AddScoped<IDiagramService, DiagramService>();

// CORS policy for Blazor client and Azure-hosted URLs (used by SignalR)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins(
            "https://blazor.syncfusion.com/",
            "https://sfblazor.azurewebsites.net/"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCookiePolicy(new CookiePolicyOptions
{
    HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,  // Always make cookies HttpOnly
    Secure = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always,
    MinimumSameSitePolicy = SameSiteMode.Strict  // SameSiteStrict to prevent cross-site requests
});

app.UseRouting();
// Important for SignalR WebSocket upgrade when hosting client separately
app.UseCors("AllowBlazorClient");
app.UseAuthorization();
app.MapControllerRoute(name: "default",
    pattern: "{controller}/{action}");
app.MapRazorPages();

app.UseFileServer();
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    DefaultContentType = "plain/text",
    FileProvider = new PhysicalFileProvider(
    Path.Combine(Directory.GetCurrentDirectory(), "Pages")),
    RequestPath = "/Pages"
});

app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    DefaultContentType = "plain/text",
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Models")),
    RequestPath = "/Models"
});

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
    // DiagramHub for real-time Syncfusion Diagram collaboration
    endpoints.MapHub<DiagramHub>("/diagramHub");
});

app.Run();

