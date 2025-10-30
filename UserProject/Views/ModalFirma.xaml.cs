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

    //Propiedad publica para guardar la firma
    public string firmaBase64 { get; private set; }

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
    //Metodo para limpiar la firma
    private void LimpiarFirma(object sender, EventArgs e)
	{
		paths.Clear();  //Esto limpia todos los trazos 
        ((SKCanvasView)FirmaCanvas).InvalidateSurface();//Este hace que el canvas salga de nuevo en blanco, regenera el cnavas en blanco 
    }
	private async void GuardarFirma(object sender, EventArgs e)
	{
        //Crear un bitmap con el tamaño del canvas
        //Bitmap, (Maapa de bits) imagen digital formada por pixeles
        //Aqui se obtendra el ancvho y alto del dibujo de la firma
        int widthFirma = (int)FirmaCanvas.CanvasSize.Width;
        int heightFirma = (int)FirmaCanvas.CanvasSize.Height;

        //Se crea el bitmap Vacio del tamaño del canvas
        using var bitmap = new SKBitmap(widthFirma, heightFirma); //Vairbales definidas para el ancho y alto
        //Crea un canvas temporal para pintar sobre el bitmap
        using var canvas = new SKCanvas(bitmap);
        canvas.Clear(SKColors.White);

        //Crear llapiz virtual para escribir
        using var pincel = new SKPaint 
        {
            Color = SKColors.Black,
            StrokeWidth = 4, 
            IsAntialias = true, //Suavizar Bordes de lineas
            Style = SKPaintStyle.Stroke
        };

        foreach (var path in paths) //path es la lista de trazos
            canvas.DrawPath(path, pincel); // Aqui dice que dibujar el trazo con el pincel 


        // Convertir la firma a imagen y luego a base64 
        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        // GUARDAR EN LA PROPIEDAD PÚBLICA
        firmaBase64 = Convert.ToBase64String(data.ToArray());

        //Cerrar el modal y mostrar la firma 
         CloseAsync();


	}
}