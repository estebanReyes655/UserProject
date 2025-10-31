using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui; // Se importa la libreria para la firma
using SkiaSharp.Views.Maui.Controls.Hosting;
using Userproject.Data;
using UserProject.ViewModels;
using UserProject.Views; //Importacion de BD


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
            builder.Services.AddSingleton<servicioBaseDatos>(s => new servicioBaseDatos(dbPath));


            //----------- Registrar el ViewModel y la Vista
            builder.Services.AddSingleton<UserViewModel>();       //  Mantiene la misma lista y conexión 
            builder.Services.AddTransient<CrearUserViewModel>();  //  Se crea nuevo cada vez que se abre
            // Definicion de vistas
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ViewCrearUser>();
            builder.Services.AddTransient<ViewDetalles>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
