using AutoMapper;
using exhibition.Services.exhibitions.Models;
using FluentValidation;

namespace exhibition.Api.Controllers.Models
{
    public class AddExhibitionRequest
    {
       public DateTime Date { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Place { get; set; }=String.Empty;

    }

    public class AddExhibitionRequestValidator : AbstractValidator<AddExhibitionRequest>
    {
        public AddExhibitionRequestValidator()
        {
            RuleFor(x =>x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Place)
                .NotEmpty().WithMessage("Place is required.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required");
        }
    }

    public class AddExhibitionRequestProfile : Profile
    {
        public AddExhibitionRequestProfile()
        {
            CreateMap<AddExhibitionRequest, AddExhibitionModel>()
                ;
        }
    }
}
