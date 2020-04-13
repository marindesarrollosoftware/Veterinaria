using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Veterinaria.Common.Helpers;
using Veterinaria.Common.Models;

namespace Veterinaria.Prism.ViewModels
{
    public class PetItemViewModel : PetResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _SelectPetCommand;

        public PetItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectPetCommand => _SelectPetCommand ?? (_SelectPetCommand = new DelegateCommand(SelectPet));

        private async void SelectPet()
        {
            //var paramaters = new NavigationParameters
            //{
            //    { "pet", this }
            //};
            //await _navigationService.NavigateAsync("HistoriesPage", paramaters);

            Settings.Pet = JsonConvert.SerializeObject(this);

            await _navigationService.NavigateAsync("PetTabbedPage");
        }
    }
}
