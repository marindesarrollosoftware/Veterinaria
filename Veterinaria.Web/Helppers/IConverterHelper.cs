using System.Threading.Tasks;
using Veterinaria.Web.Data.Entities;
using Veterinaria.Web.Models;

namespace Veterinaria.Web.Helppers
{
    public interface IConverterHelper
    {
        Task<Pet> ToPetAsync(PetViewModel model, string path, bool isNew);
        PetViewModel ToPetViewModel(Pet pet);

        Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew);
        HistoryViewModel ToHistoryViewModel(History history);
    }
}