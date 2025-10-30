using CommunityToolkit.Maui.Extensions;
using UserProject.ViewModels; //Traer el view model

namespace UserProject.Views 
{
    public partial class MainPage : ContentPage
    {
        private readonly UserViewModel _ViewModel;
        // Recibir viewMOdel como parametro
        public MainPage(UserViewModel viewModel)
        {
            InitializeComponent();

            //Guardar el viewModel en clase privada para usarla dentro de la clase MainPage
            _ViewModel = viewModel;
            BindingContext = _ViewModel;

            _ = _ViewModel.CargarUsuariosAsync();
        }
        private async void CrearNuevo(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ViewCrearRoute");
        }


    }
}
