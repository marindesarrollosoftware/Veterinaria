using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Web.Data;

namespace Veterinaria.Web.Helppers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContex;

        public CombosHelper(DataContext datacontex)
        {
            _dataContex = datacontex;
        }
        public IEnumerable<SelectListItem> GetComboPetTypes()
        {
            //var list = new List<SelectListItem>();
            //foreach (var petType in _datacontex.PetTypes)
            //{
            //    list.Add(new SelectListItem { 
            //    Text = petType.Name,
            //    Value = $"{petType.Id}"
            //    });
            //}

            var list = _dataContex.PetTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"
            })
                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a pet type..]",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboServiceTypes()
        {
            var list = _dataContex.ServiceTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"
            })
                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a service type..]",
                Value = "0"
            });
            return list;
        }

    }
}
