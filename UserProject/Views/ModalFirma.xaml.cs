using CommunityToolkit.Maui.Views;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace UserProject;

public partial class ModalFirma : Popup
{
	// -----lISTA PÁRA GUARDAR TRAZOS DE FIRMA
    private List<SKPath> paths = new();
    private SKPath currentPath;
    public ModalFirma()
	{
		InitializeComponent();
	}

    // ---------- Metodo para capturar el movimiento
    private void CapturarFirma(object sender, SKTouchEventArgs e)
    {
        //----- Comprobar si el usuario acaba de tocar la pantalla
        if (e.ActionType == SKTouchAction.Pressed)
        {
            currentPath = new SKPath(); // Crea el trazo
            currentPath.MoveTo(e.Location); //Mueve el trazo a donde lo lleve el usuario 
            paths.Add(currentPath); //Agregea los trazos a la lista de Trazos de la firma 
        }
        //----- Detectar el movimiento 
        else if (e.ActionType == SKTouchAction.Moved)
        {
            if (currentPath != null) // Verifica que el trazo este activo 
                currentPath.LineTo(e.Location);
        }

      ((SKCanvasView)sender).InvalidateSurface(); //Actualizar los moviemientos  y redibujar
        e.Handled = true;
    }
     //---------- Metodo para dibujar la firma 
    private void DibujarFirma(object sender, SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas; //Obtener la pantalñlita para escribir 
        canvas.Clear(SKColors.White);

         // Configuración de estilo para el lapiz
        using var paint = new SKPaint
        {
            Color = SKColors.Black,
            StrokeWidth = 4,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke
        };
        // Dibujar todos los trazos de la lista 
        foreach (var path in paths)
            canvas.DrawPath(path, paint);
    }

    // ---------- FUNCIONES PARA BOTONES DEL MODAL ------------
    private void CerrarModal(object sender, EventArgs e)
    {
        CloseAsync();
    }
    private void LimpiarFirma(object sender, EventArgs e)
	{
		
	}
	private void GuardarFirma(object sender, EventArgs e)
	{
		
	}
}