using AutoMapper;
using exhibition.Common.Exceptions;
using exhibition.Common.Validator;
using exhibition.Services.exhibitions.Models;
using exhibitions.Context;
using exhibitions.Context.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace exhibition.Services.exhibitions
{
    public class ExhibitionService : IExhibitionService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<AddExhibitionModel> addExhibitionModelValidator;

        public ExhibitionService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper,
            IModelValidator<AddExhibitionModel> addBookModelValidator)
        {
            this.mapper = mapper;
            this.contextFactory= contextFactory;
            this.addExhibitionModelValidator= addBookModelValidator;
        }
        public  async Task<ExhibitionModel> AddExhibition(AddExhibitionModel model)
        {
            addExhibitionModelValidator.Check(model);
            using var context = await contextFactory.CreateDbContextAsync();
            var exhibition = mapper.Map<Exhibition>(model);
            await context.Exhibitions.AddAsync(exhibition);
            context.SaveChanges();
            return mapper.Map<ExhibitionModel>(exhibition);
        }

        public async Task DeleteExhibition(int exhibitionId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var exhibition = await context.Exhibitions.FirstOrDefaultAsync(x => x.Id.Equals(exhibitionId))
                ?? throw new ProcessException($"The exhibitions (id: {exhibitionId}) was not found");
            context.Remove(exhibition);
            context.SaveChanges();
        }

        public async Task<ExhibitionModel> GetExhibition(int exhibitionId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var exhibition = await context.Exhibitions.FirstOrDefaultAsync(x => x.Id.Equals(exhibitionId));
            var data = mapper.Map<ExhibitionModel>(exhibition);
            return data;
        }

        public async Task<IEnumerable<ExhibitionModel>> GetExhibitions()
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var exhibitions = context
                .Exhibitions
                .AsQueryable();
            var data = (await exhibitions.ToListAsync()).Select(exhibition => mapper.Map<ExhibitionModel>(exhibition));
            return data;
        }
    }
}
