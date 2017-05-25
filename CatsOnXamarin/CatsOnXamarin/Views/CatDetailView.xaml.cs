using System;
using CatsOnXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatsOnXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatDetailView : ContentPage
    {
        public Cat SelectedCat;

        public CatDetailView(Cat selectedCat)
        {
            InitializeComponent();

            SelectedCat = selectedCat;
            BindingContext = SelectedCat;

            ButtonWebSite.Clicked += ButtonWebSite_Clicked;
        }

        private void ButtonWebSite_Clicked(object sender, EventArgs e)
        {
            if (SelectedCat.WebSite.StartsWith("http"))
            {
                Device.OpenUri(new Uri(SelectedCat.WebSite));
            }
        }
    }
}
