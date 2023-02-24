using Lab.ChatGP.Api.Interfaces;
using Lab.ChatGP.Api.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Lab.ChatGP.Api.ChatGPTServices;

public class ChatGPTClient : IChatGPTClient
{
    public readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public ChatGPTClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }


    public async Task<ChatGptResponse?> CallChat(string input)
    {
        var chatGptInput = new ChatGptInput(input);

        var token = _configuration.GetValue<string>("ChatGPTKey");

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var content = new StringContent(
            JsonSerializer.Serialize(chatGptInput),
            Encoding.UTF8,
            "application/json");

        var responseMessage = await _httpClient.PostAsync($"https://api.openai.com/v1/completions", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            var chatGptResponse = await responseMessage.Content.ReadFromJsonAsync<ChatGptResponse>();

            if (chatGptResponse is not null)
                return chatGptResponse;
        }

        if(responseMessage.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            return ChatGptResponse
        return null;


    }
}
