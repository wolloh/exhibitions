using exhibition.Services.exhibitions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exhibition.Services.exhibitions
{
    public interface IExhibitionService
    {
        Task<IEnumerable<ExhibitionModel>> GetExhibitions();
        Task<ExhibitionModel> GetExhibition(int exhibitionId);
        Task<ExhibitionModel> AddExhibition(AddExhibitionModel model);
        Task DeleteExhibition(int exhibitionId);
    }
}
