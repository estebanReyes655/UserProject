
using CommunityToolkit.Maui.Extensions;
using System.Threading.Tasks;
using Userproject.Data;
using UserProject.ViewModels;

namespace UserProject.Views;

public partial class ViewCrearUser : ContentPage
{
	public ViewCrearUser(CrearUserViewModel ViewModel)
	{
		InitializeComponent();
        BindingContext = ViewModel;
        

    }

    // ----- Metodo para abrir el modal
    private async void AgregarFirma(object sender, EventArgs e) 
    {
        var modal = new ModalFirma(); // Variable para abrir el modal
        var result = await this.ShowPopupAsync(modal);

        //Aqui primero se guaradra la firma en el view modal, al guardar el usuario esta ya se guardara en la BD
        if (!string.IsNullOrEmpty(modal.firmaBase64))
        {
            if (BindingContext is CrearUserViewModel vm) //vm -- Variable local para guardar firma 
            {
                vm.FirmaUsuario = modal.firmaBase64; //Guardar la fima en el view Model 
            }

            //Este es la funcion para mostrar la firma agregada
            MostrarFirma(modal.firmaBase64);
        }
    }
    //Funcion convertir el base64 en imagen, y ver en pantalla 
    private void MostrarFirma(string firmaBase64)
    {
        try
        {
            //Convertir de base64 a bytes, se toma el texto y se convierte a bytes 
            byte[] imagenBytes = Convert.FromBase64String(firmaBase64);

            //Crear stream desde los bytes
            //Se crea un canal para que la etiqueta image de MAUUI pueda leerla y mostrala
            var stream = new MemoryStream(imagenBytes);

            //Asignar el control Image
            ImagenFirma.Source = ImageSource.FromStream(() => stream);

            //Mostrar el contenedor de la firma 
            contenedorFirma.IsVisible = true;

            //Poner funcion para que cuando alla una firma alla se cambie el texcto del boton 

        }
        catch (Exception ex) 
        {
            DisplayAlert("Error", $"No se pudo mostrar la firma: {ex.Message}", "Ok");
        }
    }


}