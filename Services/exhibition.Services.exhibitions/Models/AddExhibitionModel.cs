using AutoMapper;
using exhibitions.Context.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exhibition.Services.exhibitions.Models
{
    public  class AddExhibitionModel
    {
        public DateTime Date { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Place { get; set; } = String.Empty;
    }
    public class AddExhibitionModelValidator : AbstractValidator<AddExhibitionModel>
    {
        public AddExhibitionModelValidator()
        {
            RuleFor(x => x.Name)
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
            CreateMap<AddExhibitionModel, Exhibition>()
                ;
        }
    }
}
