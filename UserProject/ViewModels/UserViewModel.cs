using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Userproject.Data;

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



    }
}
