#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Services;
using Microsoft.Extensions.AI;
using Syncfusion.EJ2.AI;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace EJ2CoreSampleBrowser_NET8.Pages.RichTextEditor;

public class EditorService {
    private readonly IChatClient _chatClient;

    public EditorService(IChatClient chatClient)
    {
        _chatClient=chatClient;
    }

    public async Task StreamResponseAsync(HttpRequest request, HttpResponse response)
    {
        request.EnableBuffering();
        using var reader = new StreamReader(request.Body, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        var message = System.Text.Json.JsonDocument.Parse(body)
            .RootElement.GetProperty("message").GetString() ?? "";

        if (string.IsNullOrEmpty(message))
        {
            response.StatusCode=400;
            await response.WriteAsync("Message is required");
            return;
        }

        response.ContentType="text/plain; charset=utf-8";
        response.Headers.Add("Cache-Control", "no-cache");

        try
        {
            var messages = new[]
            {
                new ChatMessage(ChatRole.System, "You are a helpful assistant."),
                new ChatMessage(ChatRole.User, message)
            };

            await foreach (var chunk in _chatClient.GetStreamingResponseAsync(messages))
            {
                if (!string.IsNullOrEmpty(chunk.Text))
                {
                    await response.WriteAsync(chunk.Text);
                    await response.Body.FlushAsync();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Streaming error: {ex.Message}");
            if (!response.HasStarted)
            {
                response.StatusCode=500;
                await response.WriteAsync("Internal server error");
            }
        }
    }
}