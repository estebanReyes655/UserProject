using CommunityToolkit.Maui.Extensions;
using System.Threading.Tasks;
using UserProject.Models;
namespace UserProject.Views;


[QueryProperty(nameof(userSeleccionado), "userSeleccionado")]
public partial class ViewDetalles : ContentPage
{
	public ViewDetalles()
	{
		InitializeComponent();
	}

    //Variable privada que guarda el usuario seleccionado 
    private User _userSeleccionado;
    

    //Propiedadd publica que permite acceder al usuario seleccionado, usando setter y getter 
    public User userSeleccionado
    {
        get => _userSeleccionado;
        set
        {
            _userSeleccionado = value;
            MostrarDatos();
        }
    }


    private void MostrarDatos()
    {
        //Verifica que allan datos en el usuario seleccionado 
        if(_userSeleccionado == null)
            return;
        //Trae los datos del usuario, y los ubica en los laberls 
        lblNombre.Text = _userSeleccionado.nombreUser;
        lblDocumento.Text = _userSeleccionado.documentoUser;
        lblCorreo.Text = _userSeleccionado.correoUser;
        lblTelefono.Text = _userSeleccionado.telefonoUser;
        lblDireccion.Text = _userSeleccionado.direccionUser;
        lblEdad.Text = $"{_userSeleccionado.edadUser} años";

        //Descodificar el base64 para mostrar a imagen
        if (!string.IsNullOrWhiteSpace(_userSeleccionado.firmaUser)) //Comprobar que el campo no este vacio 
        {
            try
            {
                //Convertir el base64 a bytes 
                var bytes = Convert.FromBase64String(_userSeleccionado.firmaUser);
                //Crear el stream para pasar los bytes 
                imgFirma.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error al mostrar FIrma");
            }
            
        }
        

    }

    //Metodo para ir a editar  editar  Infomacion
    private async void EditarInfo(object sender, EventArgs e)
    {
        //Creacion de diccionario, este lleva clave = valor 
        var navParam = new Dictionary<string, object>
        {
            {"userSeleccionado", _userSeleccionado } // Parametro y su valor 
        };
        await Shell.Current.GoToAsync("ViewCrearRoute", navParam); //Navegacion a la page para editar 
    }

    
    


}