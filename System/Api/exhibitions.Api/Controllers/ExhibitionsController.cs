using AutoMapper;
using exhibition.Api.Controllers.Models;
using exhibition.Common.Responses;
using exhibition.Services.exhibitions;
using exhibition.Services.exhibitions.Models;
using Microsoft.AspNetCore.Mvc;

namespace exhibition.Api.Controllers
{
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/exhibitions")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ExhibitionsController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly ILogger<ExhibitionsController> logger;
        private readonly IExhibitionService exhibitionService;

        public ExhibitionsController(IMapper mapper, ILogger<ExhibitionsController> logger, IExhibitionService exhibitionService) 
        {
            this.mapper = mapper;
            this.logger = logger;
            this.exhibitionService = exhibitionService;

        }

        [ProducesResponseType(typeof(IEnumerable<ExhibitionResponse>), 200)]
        [HttpGet("")]
        public async Task<IEnumerable<ExhibitionResponse>> GetExhibitions()
        {
            var exhibitions = await exhibitionService.GetExhibitions();
            var response = mapper.Map<IEnumerable<ExhibitionResponse>>(exhibitions);

            return response;
        }



        [ProducesResponseType(typeof(ExhibitionResponse), 200)]
        [HttpGet("{id}")]
        public async Task<ExhibitionResponse> GetExhibitionById([FromRoute] int id)
        {
            var exhibition= await exhibitionService.GetExhibition(id);
            var response = mapper.Map<ExhibitionResponse>(exhibition);

            return response;
        }


        [HttpPost("")]
        public async Task<ExhibitionResponse> AddExhibition([FromBody] AddExhibitionRequest request)
        {
            var model = mapper.Map<AddExhibitionModel>(request);
            var exhibition = await exhibitionService.AddExhibition(model);
            var response = mapper.Map<ExhibitionResponse>(exhibition);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExhibition([FromRoute] int id)
        {
            await exhibitionService.DeleteExhibition(id);

            return Ok();
        }
    }
}
