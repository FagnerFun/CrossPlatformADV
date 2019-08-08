using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CrossPlatform.Domain.Interface.Service;
using CrossPlatform.Domain.Model;
using Prism.Navigation;
using Xamarin.Forms;

namespace CrossPlatform.ViewModel
{
    public class FavoriteViewModel : ViewModelBase
    {
        readonly ISerieService _serieService;
        public ICommand ItemClickCommand { get; }
        public ObservableCollection<Serie> Items { get; }
        public FavoriteViewModel(INavigationService navigationService, ISerieService serieService) : base(navigationService)
        {
            _serieService = serieService;
            Items = new ObservableCollection<Serie>();
            ItemClickCommand = new Command<Serie>(async (item) => await ItemClickCommandExecute(item));

            IsActiveChanged += FavoriteViewModel_IsActiveChanged;
        }

        private async void FavoriteViewModel_IsActiveChanged(object sender, EventArgs e)
        {
            if (IsActive)
                await ExecuteBusyAction(async () =>
                {
                    await LoadData();
                });
        }
        
        private Task ItemClickCommandExecute(Serie item)
        {
            var parameters = new NavigationParameters();
            parameters.Add("serie", item);

            return NavigationService.NavigateAsync("SeriePage", parameters);
        }
        
        
        private async Task LoadData()
        {
            var result = _serieService.GetFavoriteSeries();
            Items.Clear();
            result.ToList()?.ForEach(i =>
            {
                i.IsFavorite = true;
                Items.Add(i);
            });

            await Task.FromResult(true);

        }
    }
}
