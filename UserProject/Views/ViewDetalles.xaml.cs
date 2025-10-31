using CommunityToolkit.Maui.Extensions;
using UserProject.Models;
namespace UserProject.Views;


[QueryProperty(nameof(userSeleccionado), "userSeleccionado")]
public partial class ViewDetalles : ContentPage
{
	public ViewDetalles()
	{
		InitializeComponent();
	}

    private User _userSeleccionado;
    

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
        if(_userSeleccionado == null)
            return;

        lblNombre.Text = _userSeleccionado.nombreUser;
        lblDocumento.Text = _userSeleccionado.documentoUser;
        lblCorreo.Text = _userSeleccionado.correoUser;
        lblTelefono.Text = _userSeleccionado.telefonoUser;
        lblDireccion.Text = _userSeleccionado.direccionUser;
        lblEdad.Text = $"{_userSeleccionado.edadUser} años";

        //Descodificar el base64 para mostrar a imagen 

        if (!string.IsNullOrWhiteSpace(_userSeleccionado.firmaUser))
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

    private void verMasInfo(object sender, EventArgs e)
    {

    }
    private void EditarFirma(object sender, EventArgs e)
    {

    }
    private void VerFirma(object sender, EventArgs e)
    {

    }
    private void EditarInfo(object sender, EventArgs e)
    {

    }

    
    


}