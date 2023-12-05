

namespace BASICA
{
    public interface IBasicConnection
    {
        void OpenConnection();
        /// <summary>
        /// property que carga y devuelve 
        /// el dato que contiene 
        /// el nombre de la tabla
        /// </summary>
        string AddData { get; set; } //permite cargar y devolver el nombre de la tabla que se utilizará en las operaciones de la base de datos
    }
}
