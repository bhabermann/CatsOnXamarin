using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CatsOnXamarin.Models;
using Xamarin.Forms;

namespace CatsOnXamarin.ViewModels
{
    public class CatsViewModel : BaseViewModel
    {
        public CatsViewModel()
        {
            Cats = new ObservableCollection<Cat>();
            GetCatsCommand = new Command(async () => await GetCats(), () => !IsBusy);
        }

        private bool _busy;

        public bool IsBusy
        {
            get { return _busy; }
            set
            {
                _busy = value;
                OnPropertyChanged();
                GetCatsCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<Cat> Cats { get; set; }

        private async Task GetCats()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                var repository = new Repository();
                var items = await repository.GetCats();

                Cats.Clear();
                foreach (var cat in items)
                {
                    Cats.Add(cat);
                }
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
            {
                await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
            }
        }

        public Command GetCatsCommand { get; set; }
    }
}
