using llm_sandbox;
using MediatR;

namespace backend.Logic.Queries
{
    public class GetImageComaprisionQuery : IRequest<string>
    {
        public string Prompt { get; set; }
    }

    public class GetImageComaprisionQueryHandler : IRequestHandler<GetImageComaprisionQuery, string>
    {
        public async Task<string> Handle(GetImageComaprisionQuery request, CancellationToken cancellationToken)
        {
            var aecTech = new AECTechLLM();

            var response = await aecTech.GetImageResponse();

            return response.Items.First().ToString();
        }
    }
}
