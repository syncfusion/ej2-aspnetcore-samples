#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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

namespace EJ2CoreSampleBrowser.Services
{

    public class AIService : IChatInferenceService
    {
        private readonly UserTokenService _userTokenService;
        private ChatParameters chatParameters_history = new ChatParameters();
        private IChatClient _chatClient;

        public AIService(UserTokenService userTokenService, IChatClient client)
        {
            _userTokenService = userTokenService;
            this._chatClient = client ?? throw new ArgumentNullException(nameof(client));
        }


        /// <summary>
        /// Gets a text completion from the Azure OpenAI service.
        /// </summary>
        /// <param name="prompt">The user prompt to send to the AI service.</param>
        /// <param name="returnAsJson">Indicates whether the response should be returned in JSON format. Defaults to <c>true</c></param>
        /// <param name="appendPreviousResponse">Indicates whether to append previous responses to the conversation history. Defaults to <c>false</c></param>
        /// <param name="systemRole">Specifies the systemRole that is sent to AI Clients. Defaults to <c>null</c></param>
        /// <returns>The AI-generated completion as a string.</returns>
        public async Task<string> GetCompletionAsync(string prompt, bool returnAsJson = true, bool appendPreviousResponse = false, string systemRole = null, int outputTokens = 2000)
        {
            string systemMessage = returnAsJson ? "You are a helpful assistant that only returns and replies with valid, iterable RFC8259 compliant JSON in your responses unless I ask for any other format. Do not provide introductory words such as 'Here is your result' or '```json', etc. in the response" : !string.IsNullOrEmpty(systemRole) ? systemRole : "You are a helpful assistant";
            try
            {
                ChatParameters chatParameters = appendPreviousResponse ? chatParameters_history : new ChatParameters();
                if (appendPreviousResponse)
                {
                    if (chatParameters.Messages == null)
                    {
                        chatParameters.Messages = new List<ChatMessage>() {
                        new ChatMessage(ChatRole.System,systemMessage),
                    };
                    }
                    chatParameters.Messages.Add(new ChatMessage(ChatRole.User, prompt));
                }
                else
                {
                    chatParameters.Messages = new List<ChatMessage>(2) {
                    new ChatMessage (ChatRole.System, systemMessage),
                    new ChatMessage(ChatRole.User,prompt),
                };
                }
                chatParameters.MaxTokens = outputTokens;
                var completion = await GetChatResponseAsync(chatParameters);
                if (appendPreviousResponse)
                {
                    chatParameters_history?.Messages?.Add(new ChatMessage(ChatRole.Assistant, completion));
                }
                return completion;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception has occurred: {ex.Message}");
                return "";
            }
        }

        public async Task<string> GenerateResponseAsync(ChatParameters options)
        {
            var regex = new Regex(@"fingerprintID\s*:\s*([A-Za-z0-9_\-.:+/=]+)", RegexOptions.IgnoreCase);

            // Scan from newest to oldest
            string userCode = string.Empty;
            for (int i = options.Messages.Count - 1; i >= 0; i--)
            {
                string text = options.Messages[i].Text ?? string.Empty;
                var match = regex.Match(text);
                if (match.Success)
                {
                    userCode = match.Groups[1].Value;
                    break;
                }
            }
            int remainingTokens = 0;
            if (!string.IsNullOrEmpty(userCode))
            {
                remainingTokens = await _userTokenService.GetRemainingTokensAsync(userCode);
                int inputTokens = options.Messages.Sum(message => message.Text.Length / 4);

                if (remainingTokens <= inputTokens)
                {
                    //await _userTokenService.ShowAlert(userCode);
                    return null;
                }
            }
            // Create a completion request with the provided parameters
            var completionRequest = new ChatOptions
            {
                Temperature = options.Temperature ?? 0.5f,
                TopP = options.TopP ?? 1.0f,
                MaxOutputTokens = options.MaxTokens ?? 2000,
                FrequencyPenalty = options.FrequencyPenalty ?? 0.0f,
                PresencePenalty = options.PresencePenalty ?? 0.0f,
                StopSequences = options.StopSequences
            };
            try
            {
                ChatResponse completion = await _chatClient.GetResponseAsync(options.Messages, completionRequest);
                if (!string.IsNullOrEmpty(userCode))
                {
#if !STAGING
                    await _userTokenService.UpdateTokensAsync(userCode, (int)(remainingTokens - completion.Usage.TotalTokenCount));
#endif
                }
                return completion.Text.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<string> GetChatResponseAsync(ChatParameters options)
        {
            string userCode = await _userTokenService.GetUserFingerprintAsync();
            int remainingTokens = await _userTokenService.GetRemainingTokensAsync(userCode);
            int inputTokens = options.Messages.Sum(message => message.Text.Length / 4);

            if (remainingTokens <= inputTokens)
            {
                await _userTokenService.ShowAlert(userCode);
                return null;
            }
            // Create a completion request with the provided parameters
            var completionRequest = new ChatOptions
            {
                Temperature = options.Temperature ?? 0.5f,
                TopP = options.TopP ?? 1.0f,
                MaxOutputTokens = options.MaxTokens ?? 2000,
                FrequencyPenalty = options.FrequencyPenalty ?? 0.0f,
                PresencePenalty = options.PresencePenalty ?? 0.0f,
                StopSequences = options.StopSequences
            };
            try
            {
                ChatResponse completion = await _chatClient.GetResponseAsync(options.Messages, completionRequest);
#if !STAGING
                await _userTokenService.UpdateTokensAsync(userCode, (int)(remainingTokens - completion.Usage.TotalTokenCount));
#endif
                return completion.Text.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task StreamAsync([FromBody] ChatRequest request, HttpContext httpContext)
        {
            var response = httpContext.Response;
            
            if (string.IsNullOrWhiteSpace(request?.Message))
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                await response.WriteAsync("Message cannot be empty.");
                return;
            }
            
            response.ContentType = "text/plain";
            try
            {
                var userId = httpContext.Request.Headers["Authentication"].ToString();

                var validationResult = await ValidateAndGetUserTokensAsync(userId, request.Message);
                string userCode = validationResult.userCode;
                int remainingTokens = validationResult.remainingTokens;

                if (remainingTokens < 0)
                {
                    var tokenData = await _userTokenService.CheckAndResetTokensAsync(userCode);
                    string msg = "";
                    if (tokenData.TryGetValue(userCode, out var info))
                    {
                        var nextResetTime = info.DateOfLogin.AddHours(24).ToString("f");
                        msg=$"You have reached your token limit. Your tokens will reset on {nextResetTime}. Download our <a href=\"https://github.com/syncfusion/ej2-aspnetcore-samples.git\" target=\"_blank\">Syncfusion AspNet Core Samples</a> from GitHub to explore this sample locally with your own API key.";
                    }
                    response.StatusCode = 402;
                    response.ContentType = "application/json";
                    await response.WriteAsync($"{msg}");
                    return;
                }

                int tokensUsed = 0;

                await foreach (var chunk in StreamCompletionAsync(
                    prompt: request.Message,
                    appendPreviousResponse: true,
                    systemRole: null,
                    returnAsJson: false,
                    cancellationToken: httpContext.RequestAborted))
                {
                    tokensUsed += chunk.Length / 4;
                    await response.WriteAsync(chunk);
                    await response.Body.FlushAsync();
                }
                
                if (!string.IsNullOrEmpty(userCode))
                {
                    await _userTokenService.UpdateTokensAsync(userCode, remainingTokens - tokensUsed);
                }
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Insufficient tokens"))
            {
                response.StatusCode = StatusCodes.Status402PaymentRequired;
                await response.WriteAsync("Insufficient tokens to process the request.");
            }
            catch (OperationCanceledException)
            {
                // client canceled
            }
        }

        public async IAsyncEnumerable<string> StreamCompletionAsync(
            string prompt,
            bool appendPreviousResponse = false,
            string systemRole = null,
            bool returnAsJson = true,
            CancellationToken cancellationToken = default)
        {
            string systemMessage = returnAsJson ? "You are a helpful assistant that only returns and replies with valid, iterable RFC8259 compliant JSON in your responses unless I ask for any other format. Do not provide introductory words such as 'Here is your result' or '```json', etc. in the response" : !string.IsNullOrEmpty(systemRole) ? systemRole : "You are a helpful assistant";
            ChatParameters chatParameters = appendPreviousResponse ? chatParameters_history : new ChatParameters();
            if (appendPreviousResponse)
            {
                if (chatParameters.Messages == null)
                {
                    chatParameters.Messages = new List<ChatMessage>() {
                        new ChatMessage(ChatRole.System, systemMessage),
                    };
                 }
                chatParameters.Messages.Add(new ChatMessage(ChatRole.User, prompt));
            }
            else
            {
                chatParameters.Messages = new List<ChatMessage>(2) {
                    new ChatMessage(ChatRole.System, systemMessage),
                    new ChatMessage(ChatRole.User, prompt),
                };
            }
            var completionRequest = new ChatOptions
            {
                Temperature = 0.5f,
                TopP = 1.0f,
                MaxOutputTokens = 2000,
            };
            await foreach (var chunk in _chatClient.GetStreamingResponseAsync(
                chatParameters.Messages,
                completionRequest,
                cancellationToken))
            {
                yield return chunk.Text;
            }
        }
        private async Task<(string userCode, int remainingTokens)> ValidateAndGetUserTokensAsync(string userID, string message)
        {
            var userCode = userID;

            if (string.IsNullOrEmpty(userCode))
            {
                return (string.Empty, -1);
            }

            int remainingTokens = await _userTokenService.GetRemainingTokensAsync(userCode);
            int inputTokens = message.Length / 4; // Approximate token count

            return remainingTokens <= inputTokens
            ? (userCode, -1)
            : (userCode, remainingTokens);
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; }
    }
}
