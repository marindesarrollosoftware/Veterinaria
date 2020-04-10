using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Common.Models;

namespace Veterinaria.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetOwnerByEmailAsync(
               string urlBase,
               string servicePrefix,
               string controller,
               string tokenType,
               string accessToken,
               string email);

        Task<Response> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);

    }
}
