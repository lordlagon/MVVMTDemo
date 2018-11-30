using Prism;
using Prism.Ioc;
using AppFarmacia.ViewModels;
using AppFarmacia.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;
using AppFarmacia.Views.Home;
using AppFarmacia.Views.Profile;
using AppFarmacia.Views.Quiz;
using AppFarmacia.Views.Offers;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using AppFarmacia.Views.Card;
using Prism.Navigation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppFarmacia
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */

        public static double ScreenHeight;
        public static double ScreenWidth;
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            AppCenter.Start("android=b66d1901-ce86-43ea-9996-09b02edfcbe0;" +
                    "uwp={Your UWP App secret here};" +
                    "ios={Your iOS App secret here}",
                    typeof(Analytics), typeof(Crashes)); 

            InitializeComponent();

            await NavigationService.NavigateAsync("LoginPage", null, true, true);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<LoyaltyCardPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<QuizPage, QuizPageViewModel>();
            containerRegistry.RegisterForNavigation<ResearchPage, ResearchPageViewModel>();
            containerRegistry.RegisterForNavigation<TabloidPage, TabloidPageViewModel>();
            containerRegistry.RegisterForNavigation<ImagePage, ImagePageViewModel>();
            containerRegistry.RegisterForNavigation<VirtualCardPage, VirtualCardPageViewModel>();
        }
    }
}
