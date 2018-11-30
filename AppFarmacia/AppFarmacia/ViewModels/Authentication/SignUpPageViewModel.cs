using AppFarmacia.Models;
using AppFarmacia.Views;
using AppFarmacia.Views.Home;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using RestClient;
using RestClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppFarmacia.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        private Person _person;
        public Person Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }

        public PersonService PersonService;
        public DelegateCommand SignUpCommand { get; set; }
        public SignUpPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            PersonService = new PersonService();
            SignUpCommand = new DelegateCommand(SignUp);
        }
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            var personModel = (Person)parameters["Person"];
            Person = personModel;
        }
        public async void SignUp()
        {
            if (Person.cpf != null && Person.razao != null)
            {
                Person.cpf.Replace("-", "").Replace(".", "");
                Person = await PersonService.Post("save", Person);
                if (Person == null)
                    await _pageDialogService.DisplayAlertAsync("Aviso", "Não foi possível cadastrar, tente de novo.", "OK");
                else
                {
                    await _pageDialogService.DisplayAlertAsync("Aviso", "Cadastrado com sucesso!", "OK");

                    await _navigationService.NavigateAsync("HomePage");
                }
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Aviso", "Preencha todos os campos", "OK");
            }
        }
    }
}
