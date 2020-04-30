using System.Threading.Tasks;
using Veterinaria.Common.Models;
using Veterinaria.Web.Data.Entities;
using Veterinaria.Web.Models;

namespace Veterinaria.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Pet> ToPetAsync(PetViewModel model, string path, bool isNew);
        PetViewModel ToPetViewModel(Pet pet);

        Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew);
        HistoryViewModel ToHistoryViewModel(History history);

        PetResponse ToPetResponse(Pet pet);
        OwnerResponse ToOwnerResponse(Owner owner);
    }
}