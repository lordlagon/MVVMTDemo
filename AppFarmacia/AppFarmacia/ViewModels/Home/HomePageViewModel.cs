using AppFarmacia.Models;
using AppFarmacia.Views.Offers;
using AppFarmacia.Views.Profile;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using RestClient;
using System.Collections.ObjectModel;

namespace AppFarmacia.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private Person _person;
        public Person Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }
        private ObservableCollection<Offer> _Offers;
        public ObservableCollection<Offer> Offers
        {
            get { return _Offers; }
            set { SetProperty(ref _Offers, value); }
        }

        public DelegateCommand ProfileCommand { get; set; }
        public DelegateCommand VirtualCardCommand { get; set; }

        public DelegateCommand TabloidCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            ProfileCommand = new DelegateCommand(ExecuteProfileCommand);
            VirtualCardCommand = new DelegateCommand(ExecuteVirtualCardCommand);
            TabloidCommand = new DelegateCommand(ExecuteTabloidCommand);
            Load();
        }

        private async void ExecuteTabloidCommand()
        {
            await _navigationService.NavigateAsync("TabloidPage");
        }

        private async void ExecuteVirtualCardCommand()
        {
            await _navigationService.NavigateAsync("VirtualCardPage");
        }
        

        private async void ExecuteProfileCommand()
        {
            var navigateParam = new NavigationParameters()
                        {
                            { "Person", Person },
                        };
            await _navigationService.NavigateAsync("ProfilePage", navigateParam);
        }
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            Person = (Person)parameters["Person"];
        }

        private void Load()
        {
            Offers = new ObservableCollection<Offer>();
            ObservableCollection<Offer> list = new ObservableCollection<Offer>() {

                new Offer { Title = "teste", Url = "http://www.farmais.com.br/images/banner_home_08092017.jpg" },
                new Offer{Title = "teste", Url="https://guia-static.gazetadopovo.com.br/fichas/5719/5719-5a235487f3231bd25200cdb726a2ccc1-cd68ed79f692c71db17a516ef3cf69bd.png"},
                new Offer { Title = "teste", Url = "https://guia-static.gazetadopovo.com.br/fichas/5719/5719-b23985d8a64444c833f0143375953b53-bb60d226803d23831e32dd23cb9bc0e1.png" },
            };
             Offers = list;
        }
    }
}
