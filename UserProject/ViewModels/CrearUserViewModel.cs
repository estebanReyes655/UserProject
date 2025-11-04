
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Userproject.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UserProject.Models;

namespace UserProject.ViewModels
{   // Definir la clase y heredar de la clase ObservableObject
    //ObservableObject acompañado con [ObservableProperty] - Herramienta del CommunityToolkit
    //ObservableObject = automatiza el enlace entre ViewModel y vista
    //partial permite que CommunityToolkit.MVVM genere automáticamente propiedades públicas y comandos detrás de escena.
    public partial class CrearUserViewModel : ObservableObject
    {
        // Intancia del servicio de la BD
        private readonly servicioBaseDatos _servicioBD;
        //Propiedad para editar el usuario
        public User UsuarioEditado { get; set; }


        //Constructor del view model Crear 
        public CrearUserViewModel(servicioBaseDatos servicioBD)
        {
            _servicioBD = servicioBD;
        }


        //Enlazar los atributos con los campos Entry de la vista 
        // Aqui el nombre de la variable puede ser cualquiera, luego se conectara con los atributos de la BD
        [ObservableProperty] private int idUsuario; // Solo se usa cuando es edición
        [ObservableProperty] private string nombreUsuario;
        [ObservableProperty] private string documentoUsuario;
        [ObservableProperty] private string correoUsuario;
        [ObservableProperty] private string telefonoUsuario;
        [ObservableProperty] private string direccionUsuario;
        [ObservableProperty] private int? edadUsuario; //En C# no se permite int nulls enntonces hacemos que pueda ser nulo con ?
        [ObservableProperty] private string firmaUsuario;


        //Comando para guardar 
        [RelayCommand] //Pertenece a la libreria comunityToolkit, genera automaticamenteun comando para enlazar
        public async Task GuardarAsync()
        {
            try
            {
                if (UsuarioEditado != null)
                {
                    //Cuando sea editar 
                    UsuarioEditado.nombreUser = NombreUsuario;
                    UsuarioEditado.documentoUser = DocumentoUsuario;
                    UsuarioEditado.correoUser = CorreoUsuario;
                    UsuarioEditado.telefonoUser = TelefonoUsuario;
                    UsuarioEditado.direccionUser = DireccionUsuario;
                    UsuarioEditado.edadUser = EdadUsuario ?? 0; //Este es int, si es null = 0
                    UsuarioEditado.firmaUser = FirmaUsuario;

                    await _servicioBD.UpdateUserAsync(UsuarioEditado);
                    await Shell.Current.GoToAsync("ViewInicioRoute"); //Al guardar vuelve al inicio 

                }
                else
                // Cuando sea para crear 
                {
                    //Verificar  que los campos se llenen 
                    if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(documentoUsuario) ||
                        string.IsNullOrWhiteSpace(correoUsuario) || string.IsNullOrWhiteSpace(telefonoUsuario) ||
                        string.IsNullOrWhiteSpace(direccionUsuario) ||
                        string.IsNullOrWhiteSpace(firmaUsuario))
                    {
                        //Si estos cmapos requeridos no tienen nada sale alerta de que se requiere
                        await Shell.Current.DisplayAlert("Error", "Por favor, completa los campos obligatorios.", "OK");
                        return;
                    }

                    //Creación del objeto de la clase User
                    var nuevoUsuario = new User
                    {
                        // Aqui se defibnen nombre de los atributos de la clase = nombre de los atributos del view model
                        idUser = idUsuario, //  Si está vacío, crea; si tiene valor, actualiza
                        nombreUser = nombreUsuario,
                        documentoUser = documentoUsuario,
                        correoUser = correoUsuario,
                        telefonoUser = telefonoUsuario,
                        direccionUser = direccionUsuario,
                        edadUser = edadUsuario ?? 0, //Si es null que se le asigne 0 
                        firmaUser = firmaUsuario
                    };

                    await _servicioBD.GuardarUserAsync(nuevoUsuario);
                    //await Shell.Current.DisplayAlert("Éxito", "Usuario guardado correctamente", "OK");
                    await Shell.Current.GoToAsync("ViewInicioRoute"); // vuelve a la página anterior (MainPage)



                    //Limpiar campos 
                    //Usar mayusculas al inincio de las propiedades, ya que la propiedad en community tools lo requiere
                    // Se limpian para que los campos se muestren vacios 
                    NombreUsuario = DocumentoUsuario = CorreoUsuario = TelefonoUsuario = DireccionUsuario = FirmaUsuario = string.Empty;

                    EdadUsuario = 0;
                }
            }
            catch (Exception ex)
            {
                //Si hay error mostrara este mensdaje y no cerrara la plicacion 
                await Shell.Current.DisplayAlert("Error", $"Ocurrió un problema al guardar: {ex.Message}", "OK");
            }
            



           
        }
    }
}
