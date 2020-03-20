using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Veterinaria.Web.Helppers
{
    public interface IImageHelper
    {
        Task<string> UpLoadImageAsync(IFormFile imageFile);
    }
}