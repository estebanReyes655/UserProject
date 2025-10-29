using CommunityToolkit.Maui.Extensions;

namespace UserProject.Views 
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private async void VerDetalles(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ViewDetallesRoute");
        }


    }
}
