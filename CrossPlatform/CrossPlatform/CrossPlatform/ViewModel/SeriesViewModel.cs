using CrossPlatform.Domain.Interface.Service;
using CrossPlatform.Domain.Model;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrossPlatform.ViewModel
{
    public class SeriesViewModel: ViewModelBase
    {
        readonly ISerieService _serieService;
        public ICommand ItemClickCommand { get; }
        public ObservableCollection<Serie> Items { get; }

        public SeriesViewModel(INavigationService navigationService, ISerieService serieService) : base(navigationService)
        {
            _serieService = serieService;
            Items = new ObservableCollection<Serie>();
            ItemClickCommand = new Command<Serie>(async (item) => await ItemClickCommandExecute(item));
            IsActiveChanged += SeriesViewModel_IsActiveChanged;
        }

        private async void SeriesViewModel_IsActiveChanged(object sender, EventArgs e)
        {
            if (IsActive)
                await ExecuteBusyAction(async () =>
            {
                await LoadDataAsync();
            });
        }
        
        private Task ItemClickCommandExecute(Serie item)
        {
            var parameters = new NavigationParameters();
            parameters.Add("serie", item);

            return NavigationService.NavigateAsync("SeriePage", parameters);
        }

        async Task LoadDataAsync()
        {
            var result = await _serieService.GetSeriesAsync();
            Items.Clear();
            result?.Series.ToList()?.ForEach(i => Items.Add(i));
        }
    }
}
