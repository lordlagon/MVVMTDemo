using AppFarmacia.Models;
using AppFarmacia.Views;
using AppFarmacia.Views.Home;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestClient;
using RestClient.Services;
using System.Collections.ObjectModel;
using AppFarmacia.Validators;
using Prism.Navigation;
using Prism.Services;

namespace AppFarmacia.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        private Person _person;
        public Person Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }

        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        public DelegateCommand SignUpCommand { get; set; }
        public DelegateCommand LoginCommand { get; set; }

        public PersonService PersonService = new PersonService();
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService): base(navigationService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            People = new ObservableCollection<Person>
            {
                new Person()
            };
            Person = new Person();
            SignUpCommand = new DelegateCommand(SignUp);
            LoginCommand = new DelegateCommand(Login);

        }
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void SignUp()
        {
            App.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }
        public async void Login()
        {
            CpfValidator cpfValidator = new CpfValidator();

            if (Person.cpf != null)
            {
                if (cpfValidator.ValidateCpf(Person.cpf))
                {
                    People = await PersonService.Get("getbyCpf?cpf=" + Person.cpf);
                    if (People.Count == 0)
                    {
                        var navigateParam = new NavigationParameters
                        {
                            {"Person", Person }
                        };
                        await _navigationService.NavigateAsync("SignUpPage", navigateParam);
                    }
                    else
                    {
                        var navigateParam = new NavigationParameters()
                        {
                            { "Person", People[0] },
                        };
                        await _navigationService.NavigateAsync("HomePage", navigateParam);
                    }
                }
                else
                {
                    await _pageDialogService.DisplayAlertAsync("Aviso", "Digite um CPF válido", "Ok");
                }
            }
            else
                await _pageDialogService.DisplayAlertAsync("Aviso", "Preencha o seu CPF", "Ok");
        }
    }
}
