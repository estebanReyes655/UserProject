using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui; // Se importa la libreria para la firma
using SkiaSharp.Views.Maui.Controls.Hosting;
using Userproject.Data; //Importacion de BD

namespace UserProject
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit() //Se habilita la libreria ppara el modal
                .UseSkiaSharp() // lIbreria usada para la firma
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // ---------- Registro del servicio de la Base de datos 

            //Crear ruta para guardar archivo de la BD 
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "UserProject.db3");
            //Crear nueva instancia  de BD
            builder.Services.AddSingleton(new servicioBaseDatos(dbPath));


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
