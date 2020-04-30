﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Web.Data;
using Veterinaria.Web.Data.Entities;

namespace Veterinaria.Web.Helpers
{
    public class AgendaHelper : IAgendaHelper
    {
        private readonly DataContext _dataContext;
        public AgendaHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddDaysAsync(int days)
        {
            DateTime initialDate;
            if (!_dataContext.Agendas.Any())
            {
                initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            }
            else
            {
                var agenda = _dataContext.Agendas.LastOrDefault();
                initialDate = new DateTime(agenda.Date.Year, agenda.Date.Month, agenda.Date.AddDays(1).Day, 8, 0, 0);
            }

            var finalDate = initialDate.AddDays(days);
            while(initialDate < finalDate)
            {
                if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var finalDate2 = initialDate.AddHours(10);
                    while(initialDate < finalDate2)
                    {
                        _dataContext.Agendas.Add(new Agenda
                        {
                            Date = initialDate.ToUniversalTime(),
                            IsAvailable = true
                        });

                        initialDate = initialDate.AddMinutes(30);
                    }
                    initialDate = initialDate.AddHours(14);
                }
                else
                {
                    initialDate = initialDate.AddDays(1);
                }
            }
            await _dataContext.SaveChangesAsync();
        }
    }
}
