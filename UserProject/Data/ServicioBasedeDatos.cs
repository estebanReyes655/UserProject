
//LLamamos la libreria sqlite
using SQLite;
//Llamamr los modelos 
using UserProject.Models;

namespace Userproject.Data //namespace para importaciones de codigos 
{
    public class servicioBaseDatos
    {
        // private,  para que solo se use en la clase de serivico 
        //readonly,  para que la variable sea asignada solo una vez 
        //SQLiteAsyncConnection, clase que pertenece al paquete sqlite-net-pcl. Esta permite ejecutar operaciones de la libreria.
        private readonly SQLiteAsyncConnection conexionBD;

        // Constructor de la clase 
        // La clase y el contructor deben tener el mismo nombre 
        public servicioBaseDatos(string dbPath) // El parametro que recibe es una cadena de texto, que es la ruta path donde se guardara la BD
        {
            // Crear instancia 
            conexionBD = new SQLiteAsyncConnection(dbPath);
            conexionBD.CreateTableAsync<User>().Wait(); // Crear la tyabla automaticamnete
        }

        //-------- CRUD para la tabla user

        //Traer todos los usuarios 
        //Task, ejecuta operaciones en segundo plano que me traerasn algo 
        public Task<List<User>> GetUsersAsync() 
            => conexionBD.Table<User>().ToListAsync();

        //Guardar el usuario 
        public Task<int> GuardarUserAsync(User user)
            => conexionBD.InsertAsync(user);  //Insert Agrega nuevos

        //Eliminar usuario
        public Task<int> EliminarUserAsync(User user)
            => conexionBD.DeleteAsync(user);


        //Actualizar Usuario
        public Task<int> UpdateUserAsync(User user)
            => conexionBD.UpdateAsync(user);
    }
}