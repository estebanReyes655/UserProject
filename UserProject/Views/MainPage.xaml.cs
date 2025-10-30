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

 
        }

        //  Este método recarga los usuarios
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _ViewModel.CargarUsuariosAsync();

            await DisplayAlert("Debug", $"Usuarios cargados: {_ViewModel.Users.Count}", "OK");
        }





        // ----- Rutas de botones de navegacion

        private async void CrearNuevo(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ViewCrearRoute");
        }

        private async void VerOneUser(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ViewDetallesRoute");
        }
        private async void VolverInicio(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ViewInicioRoute");
        }


    }
}
