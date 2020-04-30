using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Veterinaria.Web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UpLoadImageAsync(IFormFile imageFile);
    }
}