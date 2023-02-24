using Lab.ChatGP.Api.Models;

namespace Lab.ChatGP.Api.Interfaces;

public interface IChatGPTClient
{
    Task<ChatGptResponse?> CallChat(string input);
}
