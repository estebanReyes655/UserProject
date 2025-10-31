using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Userproject.Data;
using UserProject.Models;

// -------- ESTE VIEW MODEL ES PARA LISTAR LOS USUARIOS

namespace UserProject.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged //Esto es para notificar actualizaciones a la vista, en caso de no usar esto se usa el 'BaseModel'
    {
        //Evento de 'INotifyPropertyChanged'  para notificar cuando algun dato cambie
        public event PropertyChangedEventHandler? PropertyChanged;

        //Instancia del servicio de la BD
        // 1. TIpo de dato, el nombre de la clase del servicio
        //2. Nombre de la Variable (Instancia), la que se usara delntro del ViewModel, se usa _ para referir a variable privada
        private readonly servicioBaseDatos _servicioBD;


        //Constructor del viewModel, este es el contructor que recibe la conexion de la BD
        public UserViewModel(servicioBaseDatos servicioBD)
        {
            _servicioBD = servicioBD;

        }

        //Lista observable para mostrar los usuarios en pantalla 
        //ObservableCollection -> es la coleccion por defecto de .net para que se actualice automaticamente
        public ObservableCollection<User> Users { get; set; } = new();

        //Metodo asincrono para cargar los usuarios desde la BD
        public async Task CargarUsuariosAsync()
        {
            Users.Clear();// Esta linea limpia, para asegurar que no allan elementos repetidos
            //Llamar el servicio de BD
            var lista = await _servicioBD.GetUsersAsync();
            //Recorre e itera cada usuario y lo agrega a la Vista
            foreach (var user in lista)
                Users.Add(user);
        }

        //Metodo para guardar los usuarios 
        public async Task GuardarUsuarioAsync(User user)
        {
            await _servicioBD.GuardarUserAsync(user);
            await CargarUsuariosAsync(); //Recargar la vista con el nuevo usuario

        }

        //Metodo para eliminar 
        public async Task EliminarUsuarioAsync(User user)
        {
            await _servicioBD.EliminarUserAsync(user);

        }

        //Metodo para notificar cambios
        protected void CambiosEnPropiedades([CallerMemberName] string nombrePropiedad = null)
        {
            //Se invoca el evento PropertyChanged que notifica cambios
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }


        [RelayCommand]
        public async Task VerDetalles(User userSeleccionado)
        {
            if (userSeleccionado == null)
            {
                return;

                var navParam = new Dictionary<string, object>
                {
                    { "userSeleccionado", userSeleccionado }
                };

                await Shell.Current.GoToAsync("ViewDetallesRoute", navParam);
            }
        }


    }
}

