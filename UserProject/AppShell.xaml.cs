using UserProject.Views; //Importacion de ruta donde estan las vistas 

namespace UserProject 
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // ----- Reguistrar rutas para las vistas 
            // Se usa comillas en el nombre de la ruta para que sea diferente 
            // En caso de no usar comillas para el nombre de ruta, se usa nameof(Nombrederuta/nombreClase)
            
            //Ruta para Detalle Usuario
            Routing.RegisterRoute("ViewDetallesRoute", typeof(ViewDetalles));

            //Ruta para Crear Usuario
            Routing.RegisterRoute("ViewCrearRoute", typeof(ViewCrearUser));

            //Ruta para VolverInicio
            Routing.RegisterRoute("ViewInicioRoute", typeof(MainPage));
        }
    }
}
