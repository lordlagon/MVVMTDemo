using AppFarmacia.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AppFarmacia.ViewModels
{
    public class ResearchPageViewModel : ViewModelBase
    {
        
              private ObservableCollection<Quiz> _question;
        public ObservableCollection<Quiz> Questions
        {
            get { return _question; }
            set { SetProperty(ref _question, value); }
        }
        public ResearchPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Load();
        }

        private void Load()
        {
            Questions = new ObservableCollection<Quiz>();
            //TODO remover lista fake
            ObservableCollection<Quiz> list = new ObservableCollection<Quiz>() {

                new Quiz { Id_empresa = 9, Id_pergunta = 20, Pergunta = new Question{ Query="Qual sua satisfação?",Tipo="intervalo"},Situacao=1,Tipo="Fechada" },
                new Quiz { Id_empresa = 9, Id_pergunta = 20, Pergunta = new Question{ Query="Qual sua satisfação?",Tipo="intervalo"},Situacao=1,Tipo="Fechada" },
                new Quiz { Id_empresa = 9, Id_pergunta = 20, Pergunta = new Question{ Query="Qual sua satisfação?",Tipo="intervalo"},Situacao=1,Tipo="Fechada" },
                new Quiz { Id_empresa = 9, Id_pergunta = 20, Pergunta = new Question{ Query="Qual sua satisfação?",Tipo="intervalo"},Situacao=1,Tipo="Fechada" }
            };
            Questions = list;
        }
    }
    }

