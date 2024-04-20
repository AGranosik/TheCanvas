using Microsoft.SemanticKernel;
using Kernel = Microsoft.SemanticKernel.Kernel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.ComponentModel.DataAnnotations;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Globalization;

namespace llm_sandbox
{
    public class AECTechLLM
    {
        Kernel _kernel { get; set; }

        public AECTechLLM()
        {
            ILoggerFactory myLoggerFactory = NullLoggerFactory.Instance;

            _kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion("gpt-4-vision-preview", "")
                .Build();
        }

        public async Task<ChatMessageContent> GetImageResponse()
        {
            const string utciNow = "https://i.ibb.co/QdVTjYC/Copenhagen-UTCI-now.jpg";
            const string utci2050 = "https://i.ibb.co/tmxk8xY/Copenhagen-UTCI-2050.jpg";
            var chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();

            var chatHistory = new ChatHistory("You are an enviromental sepcialist working in AEC. Focuesd on providing feedback for urban planer");

            var list = new ChatMessageContentItemCollection
            {
                new TextContent("Provided images are results of UTCI comfort analisy of same plot in 2024(first image) and in 2050(secound image)" +
                "Can you compare those results and say what is differece between them both climates? Be breif and profesional and focus on desing impact" +
                "What would be good startegies for mitigating negative impact. Sumarize in 70 words and put strategy in 5 bullet points"),
                new ImageContent(new Uri(utciNow)),
                new ImageContent(new Uri(utci2050)),
            };
            chatHistory.AddUserMessage((ChatMessageContentItemCollection)list);

            var reply = await chatCompletionService.GetChatMessageContentAsync(chatHistory);

           
            return reply;
        }

        public async Task<string> GetResponse(string promptContent)
        {
            var prompt = @"{{$input}} You are climate specialist what can you say about climate in this city from provided data? Sumarize in 100 words";
            var gptFunction = _kernel.CreateFunctionFromPrompt(prompt, executionSettings: new OpenAIPromptExecutionSettings { MaxTokens = 1000 });
            
            
            
            var response = await _kernel.InvokeAsync(gptFunction, new() { ["input"] = promptContent });
            return response.ToString();
            }

        public async Task<ChatMessageContent> GetImageResponseCombined(string analisys1, string analisys2)
        {
            const string utciNow = "https://i.ibb.co/QdVTjYC/Copenhagen-UTCI-now.jpg";
            const string utci2050 = "https://i.ibb.co/tmxk8xY/Copenhagen-UTCI-2050.jpg";
            var chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();

            var chatHistory = new ChatHistory("You are an enviromental sepcialist working in AEC. Focuesd on providing feedback for urban planer");

            ChatMessageContentItemCollection list = new()
            {
                new TextContent("Provided images are results of UTCI comfort analisy of same plot in 2024(first image) and in 2050(secound image)" +
                "Can you compare those results and say what is differece between them both climates? Be breif and profesional and focus on desing impact" +
                "What would be good startegies for mitigating negative impact. Sumarize in 70 words and put strategy in 5 bullet points"),
                new ImageContent(new Uri(utciNow)),
                new ImageContent(new Uri(utci2050)),
                new TextContent("Here you have numeric data from same analisys. Can you calculate percentage: " + analisys1 + "2050: " + analisys2),

            };

            chatHistory.AddUserMessage(list);

            var reply = await chatCompletionService.GetChatMessageContentAsync(chatHistory);


            return reply;
        }

        public async Task<string> GetComparisonResponse(string promptContent, string otherContent)
        {
            var prompt = @" You are climate specialist.
                            You will be provided with climate data for two locations. First location is city we would like to analise and it's climate today. 
                            Secound location is predicted climate in same location but in 50 years.
                            Please compare those data and sumarize difference in 100 word. 
                            Please provide startegies to mitigate climate change for predicted data in another 100 words.
                            This is first location: {{$input}} 
                            This is other location: {{$otherInput}}";
            var gptFunction = _kernel.CreateFunctionFromPrompt(prompt, executionSettings: new OpenAIPromptExecutionSettings { MaxTokens = 1000 });



            var response = await _kernel.InvokeAsync(gptFunction, new() { ["input"] = promptContent, ["otherInput"] = otherContent });
            return response.ToString();
        }

        public async Task<string> GetComparisonResponseWithCustomAction(string action, string promptContent, string otherContent)
        {
            var prompt = @" You will get two data elements and action to be performed.
                            Action: {{$action}}. Can you make this action on following data
                            This is first data: {{$input}} 
                            This is other data: {{$otherInput}}";
            var gptFunction = _kernel.CreateFunctionFromPrompt(prompt, executionSettings: new OpenAIPromptExecutionSettings { MaxTokens = 1000 });



            var response = await _kernel.InvokeAsync(gptFunction, new() { ["action"] = action, ["input"] = promptContent, ["otherInput"] = otherContent });
            return response.ToString();
        }
        public async Task<string> GetImagePrompt(ImageContent image, string action)
        {
            var prompt = @"  {{$action}}
                            This is picture data: {{$input}} 
                            ";
            var gptFunction = _kernel.CreateFunctionFromPrompt(prompt, executionSettings: new OpenAIPromptExecutionSettings { MaxTokens = 1000 });

            var test = image.ToString();

            var response = await _kernel.InvokeAsync(gptFunction, new() { ["action"] = action, ["input"] = image.ToString()});
            return response.ToString();
        }
    }
}

