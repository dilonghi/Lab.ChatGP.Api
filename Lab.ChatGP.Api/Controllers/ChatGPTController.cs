using Lab.ChatGP.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab.ChatGP.Api.Controllers;


[ApiController]
[Route("api")]
public class ChatGPTController : ControllerBase
{
    private readonly IChatGPTClient _chatGPTClient;

    public ChatGPTController(IChatGPTClient chatGPTClient)
    {
        _chatGPTClient = chatGPTClient;
    }

    [HttpPost("v1/chat-gpt/talk")]
    public async Task<IActionResult> TalkWithChatGpt(string input)
    {
        var chatGpt = await _chatGPTClient.CallChat(input);

        return chatGpt is not null ?
             Ok(chatGpt.choices.FirstOrDefault()) :
             BadRequest("Nada a declarar");
    }
}