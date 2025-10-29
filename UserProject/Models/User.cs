// Importar libreria 
using SQLite; 

// --------- Esta es la clase 'User', que es la tabla 'User' en la base de datos 
namespace UserProject.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int idUser { get; set; }

        [MaxLength(100)]
        public string nombreUser { get; set; }

        [Unique]
        public string documentoUser { get; set; }

        public string correoUser { get; set; }

        [MaxLength(10)]
        public string telefonoUser { get; set; }

        public string direccionUser { get; set; }

        public int edadUser { get; set; }

        // la Firma es tipo string para poder guardar como base64
        public string firmaUser { get; set; }


    }
}
