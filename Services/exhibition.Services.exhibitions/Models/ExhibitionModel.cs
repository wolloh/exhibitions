using AutoMapper;
using exhibitions.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exhibition.Services.exhibitions.Models
{
    public class ExhibitionModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Place { get; set; } = String.Empty;
    }

    public class ExhibitionModelProfile : Profile
    {
        public ExhibitionModelProfile()
        {
            CreateMap<Exhibition, ExhibitionModel>();

        }
    }
}
