using CommunityToolkit.Maui.Extensions;
using UserProject.ViewModels; //Traer el view model

namespace UserProject.Views 
{
    public partial class MainPage : ContentPage
    {
        private readonly UserViewModel _ViewModel;

        //Usar variable flag, son variable de v/f para indicar estados 
        //Se usa para evitar que cargue la lista de usuarios dos veces
        //Comrabamos si ya carggamos los usuario,
        private bool _usuariosCargados = false; 

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
            //Si no se han cragado los usuarios 
            if (!_usuariosCargados)
            {
                //Carga los usuarios y marca como que ya estan cargados
                await _ViewModel.CargarUsuariosAsync();
                _usuariosCargados=true;
            }
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
