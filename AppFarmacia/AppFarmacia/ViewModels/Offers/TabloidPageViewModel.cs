using AppFarmacia.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using RestClient;
using RestClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AppFarmacia.ViewModels
{
	public class TabloidPageViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        private ObservableCollection<Tabloid> _tabloids;
        public ObservableCollection<Tabloid> Tabloids
        {
            get { return _tabloids; }
            set { SetProperty(ref _tabloids, value); }
        }

        private Tabloid _tabloid;
        public Tabloid Tabloid
        {
            get { return _tabloid; }
            set { SetProperty(ref _tabloid, value); }
        }

        public TabloidService TabloidService = new TabloidService();

        public TabloidPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            Tabloids = new ObservableCollection<Tabloid>
            {
                new Tabloid()
            };
            Tabloid = new Tabloid();

            Task.Run(async () =>
            {
                await GetTabloidAsync();
            }).GetAwaiter();

        }


        private async Task GetTabloidAsync()
        {

            //{
            //    new Tabloid { url = "http://powerfarma.com.br/Imagens/tabloide/farmais/160504-bitcoin-b.jpg" },
            //    new Tabloid{ url= "https://guia-static.gazetadopovo.com.br/fichas/5719/5719-5a235487f3231bd25200cdb726a2ccc1-cd68ed79f692c71db17a516ef3cf69bd.png"},
            //    new Tabloid { url = "https://guia-static.gazetadopovo.com.br/fichas/5719/5719-b23985d8a64444c833f0143375953b53-bb60d226803d23831e32dd23cb9bc0e1.png" },
            //};
            Tabloids = await TabloidService.Get("getTabloide");


        }
    }
}
