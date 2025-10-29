using CommunityToolkit.Maui.Extensions;

namespace UserProject.Views;

public partial class ViewCrearUser : ContentPage
{
	public ViewCrearUser()
	{
		InitializeComponent();
	}

    // ----- Metodo para abrir el modal
    private void AgregarFirma(object sender, EventArgs e)
    {
        var modal = new ModalFirma();
        this.ShowPopup(modal);
    }

    private void verMasInfo(object sender, EventArgs e)
    {

    }
    private void GuardarCambios(object sender, EventArgs e)
    {

    }
    private void VolverInicio(object sender, EventArgs e)
    {

    }
}