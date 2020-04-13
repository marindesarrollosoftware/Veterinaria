using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Veterinaria.Common.Helpers;
using Veterinaria.Common.Models;

namespace Veterinaria.Prism.ViewModels
{
    public class HistoriesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private PetResponse _pet;
        private ObservableCollection<HistoryItemViewModel> _histories;
        public HistoriesPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            Pet = JsonConvert.DeserializeObject<PetResponse>(Settings.Pet);
            Title = "Histories";

            LoadHistories();
        }

        public ObservableCollection<HistoryItemViewModel> Histories
        {
            get => _histories;
            set => SetProperty(ref _histories, value);
        }
        public PetResponse Pet
        {
            get => _pet;
            set => SetProperty(ref _pet, value);
        }

        //public override void OnNavigatedTo(INavigationParameters parameters)
        //{
        //    base.OnNavigatedTo(parameters);

        //    if (parameters.ContainsKey("pet"))
        //    {
        //        Pet = parameters.GetValue<PetResponse>("pet");
        //        Title = $"Histories of: {Pet.Name}";

        //        LoadHistories();

        //    }
        //}

        private void LoadHistories()
        {
            Histories = new ObservableCollection<HistoryItemViewModel>(Pet.Histories.Select(h => new HistoryItemViewModel(_navigationService)
            {
                Date = h.Date,
                Description = h.Description,
                Id = h.Id,
                Remarks = h.Remarks,
                ServiceType = h.ServiceType
            }).ToList()
                );
        }
    }
}
