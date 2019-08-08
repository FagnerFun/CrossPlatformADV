using CrossPlatform.Domain.Interface.Service;
using CrossPlatform.Domain.Model;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrossPlatform.ViewModel
{
    public class SerieViewModel : ViewModelBase
    {

        private const string FavoriteIcon = "star_color.png";
        private const string NotFavoriteIcon = "star_enpty.png";

        private readonly ISerieService serieService;
        public ICommand FavoriteCommand { get; }

        private Serie SerieModel { get; set; }

        public SerieViewModel(INavigationService navigationService, ISerieService serieService) : base(navigationService)
        {
            this.serieService = serieService;
            FavoriteCommand = new Command( () => Favorite());
        }

        private void Favorite()
        {
            if (IsFavorite)
            {
                serieService.RemoveFavorite(SerieModel);
                IsFavorite = !IsFavorite;
            }
            else
            {
                serieService.AddFavorite(SerieModel);
                IsFavorite = !IsFavorite;
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            SerieModel = parameters.GetValue<Serie>("serie");

            Title = SerieModel.Name;
            Name = SerieModel.OriginalName;
            OverView = SerieModel.Overview;
            Poster = SerieModel.Poster;
            BackDrop = SerieModel.BackDrop;
            ReleaseDate = SerieModel.ReleaseDate;
            Votes = SerieModel.VoteAverage;
            IsFavorite = SerieModel.IsFavorite;

            FirstLoad();
        }

        private void FirstLoad()
        {

            RaisePropertyChanged("FirstStar");
            RaisePropertyChanged("SecondStar");
            RaisePropertyChanged("ThridStar");
            RaisePropertyChanged("FourStar");
            RaisePropertyChanged("FiveStar");
            RaisePropertyChanged("IconIsFavorite");
        }

        #region propertys

        bool isFavorite;
        public bool IsFavorite
        {
            get { return isFavorite; }
            set
            {
                isFavorite = value;
                RaisePropertyChanged();
                RaisePropertyChanged("IconIsFavorite");
            }
        }


        public string IconIsFavorite
        {
            get { return  isFavorite ? "favorite_full.png" : "favorite_enpty.png"; }
        }


        string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

        string name;
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        string overview;
        public string OverView
        {
            get { return overview; }
            set { overview = value; RaisePropertyChanged(); }
        }

        string poster;
        public string Poster
        {
            get { return poster; }
            set { poster = value; RaisePropertyChanged(); }
        }

        string backdrop;
        public string BackDrop
        {
            get { return backdrop; }
            set { backdrop = value; RaisePropertyChanged(); }
        }

        double votes;
        public double Votes
        {
            get { return votes; }
            set
            {
                votes = value;
                RaisePropertyChanged();
            }
        }

        string releaseDate;
        public string ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; RaisePropertyChanged(); }
        }


        public string FirstStar
        {
            get => Votes > 2 ? FavoriteIcon : NotFavoriteIcon;
        }
        public string SecondStar
        {
            get => Votes > 4 ? FavoriteIcon : NotFavoriteIcon;
        }
        public string ThridStar
        {
            get => Votes > 6 ? FavoriteIcon : NotFavoriteIcon;
        }
        public string FourStar
        {
            get => Votes > 8 ? FavoriteIcon : NotFavoriteIcon;
        }
        public string FiveStar
        {
            get => Votes >= 9.5 ? FavoriteIcon : NotFavoriteIcon;
        }
        #endregion
    }
}
