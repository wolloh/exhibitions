using AutoMapper;
using exhibition.Services.exhibitions.Models;

namespace exhibition.Api.Controllers.Models
{
    public class ExhibitionResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Place { get; set; } = String.Empty;
    }

    public class ExhibitionResponseProfile : Profile
    {
        public ExhibitionResponseProfile()
        {
            CreateMap<ExhibitionModel, ExhibitionResponse>();
        }
    }
}
