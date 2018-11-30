using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using RestClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppFarmacia.ViewModels
{
	public class ProfilePageViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;
        private Person _person;
        public Person Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }

        public ProfilePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

        }
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            Person = (Person)parameters["Person"];
        }
    }
}
