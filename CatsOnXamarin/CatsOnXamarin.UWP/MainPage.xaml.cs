namespace CatsOnXamarin.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new CatsOnXamarin.App());
        }
    }
}
