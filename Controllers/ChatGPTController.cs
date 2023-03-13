using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace IntegratedChatGPT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGPTController : ControllerBase
    {
        [HttpGet("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            string Result = "";
            var openAI = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = openAI.Completions.CreateCompletionAsync(completionRequest);
            foreach (var completion in completions.Result.Completions)
            {
                Result += completion;
            }
            return Ok(Result);
        }
    }
}
