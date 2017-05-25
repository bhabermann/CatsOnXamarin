using CatsOnXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatsOnXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatsView : ContentPage
    {
        public CatsView()
        {
            InitializeComponent();

            ListViewCats.ItemSelected += ListViewCats_ItemSelected;
        }

        private async void ListViewCats_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCat = e.SelectedItem as Cat;
            if (selectedCat != null)
            {
                await Navigation.PushAsync(new CatDetailView(selectedCat));
                ListViewCats.SelectedItem = null;
            }
        }
    }
}
