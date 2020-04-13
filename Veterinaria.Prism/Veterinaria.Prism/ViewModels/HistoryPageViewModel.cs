using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Veterinaria.Common.Models;

namespace Veterinaria.Prism.ViewModels
{
    public class HistoryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private HistoryResponse _history;
        public HistoryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "History";
        }
        public HistoryResponse History
        {
            get => _history;
            set => SetProperty(ref _history, value);

        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("history"))
            {
                History = parameters.GetValue<HistoryResponse>("history");
            }
        }
    }
}
