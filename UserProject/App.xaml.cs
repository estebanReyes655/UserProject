
namespace UserProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
        }

        //Apartir de net 8 y 9, se cmabio la forma de inicializar  
        //Antes se podia MainPage = newAppShell 
        //AHora se sobreescribe el metodo
        protected override Window CreateWindow(IActivationState? activationState)  //CreateWindow -> punto de entrada, Devuelve un objeto Window que tiene el page raiz 
        {
            //Se crea una venta y pone a Appshel como pagina raiz
            return new Window(new AppShell());
        }

       
    }
}