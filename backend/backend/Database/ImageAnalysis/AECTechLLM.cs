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

            /*
            var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(
                        "gpt-4-turbo",                        // OpenAI Model Name
                        "sk-proj-UWB0QdowJyJKpvksgwYZT3BlbkFJ0Tlloro91YkXPoIia2nz",            // OpenAI API key
                        serviceId: "OpenAI_davinci"             // alias used in the prompt templates' config.json
            );
            */


            _kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion("gpt-4-vision-preview", "ss")
                .Build();


            //builder.Services.AddSingleton(myLoggerFactory);

           // _kernel = builder.Build();
        }

        public async Task<ChatMessageContent> GetImageResponse()
        {
            const string ImageUri = "https://i.ibb.co/QfcKD8Z/2.jpg";
            const string ImageUtll = "https://i.ibb.co/T4jgYmj/1.jpg";
            var chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();

            var chatHistory = new ChatHistory("You are an enviromental sepcialist working in AEC.");
            var list = new ChatMessageContentItemCollection
            {
                new TextContent("Provided images are results of sunlight analisy of same plot. " +
                "Can you compare those results and say what is differece between them?"),
                new ImageContent(new Uri(ImageUri)),
                new ImageContent(new Uri(ImageUtll))
            };
            chatHistory.AddUserMessage(list);

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

