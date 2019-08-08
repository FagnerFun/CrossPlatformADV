using CrossPlatform.Domain.Interface.Repository;
using CrossPlatform.Domain.Interface.Service;
using CrossPlatform.Domain.Model;
using CrossPlatform.Domain.Model.Const;
using CrossPlatform.Infra.LiteDB;
using CrossPlatform.Service;
using CrossPlatform.View;
using CrossPlatform.ViewModel;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Refit;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CrossPlatform
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"NavigationPage/{nameof(MainPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SeriesPages, SeriesViewModel>();
            containerRegistry.RegisterForNavigation<SeriePage, SerieViewModel>();
            containerRegistry.RegisterForNavigation<FavoritePage, FavoriteViewModel>();

            containerRegistry.Register<ISerieService, SerieService>();

            switch (AppSettings.DataBaseType)
            {
                case Domain.Model.Enum.DataBaseEnum.SQLite:
                    containerRegistry.Register<ISerieRepository, Infra.SQLite.SerieRepository>();
                    break;
                default: // Lite DB
                    containerRegistry.Register<ISerieRepository, Infra.LiteDB.SerieRepository>();
                    break;
            }

            #region refit

            var client = new HttpClient()
            {
                BaseAddress = new Uri(AppSettings.ApiUrl),
                Timeout = TimeSpan.FromSeconds(90)
            };

            containerRegistry.RegisterInstance<ITMDB>(RestService.For<ITMDB>(client));

            #endregion
        }
    }
}
