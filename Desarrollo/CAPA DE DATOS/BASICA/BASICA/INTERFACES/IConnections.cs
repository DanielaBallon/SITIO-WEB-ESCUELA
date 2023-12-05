  
    
namespace BASICA
{ 

    /// <summary>
    /// inrface de la clase conection
    /// </summary>
    public interface IConnection : IParameters
    {
        /// <summary>
        /// Crea una conexion
        /// </summary>
        /// <param name="StoreProc">nombre del store procedure procedimiento de almacentado</param>
        /// <param name="Data">Data auxiliar</param>
        void CreateCommand(string StoreProc, string Data);
        /// <summary>
        /// inserta un objeto
        /// </summary>
        /// <returns>el id de el registro</returns>
        int Insert();
        /// <summary>
        /// elimina un registro de la tabla
        /// </summary>
        void Delete();
        /// <summary>
        /// devuelve el registro
        /// </summary>
        /// <returns>Datarow del registro</returns>
        System.Data.DataRow Find();
        /// <summary>
        /// verifica si existe
        /// </summary>
        /// <returns>Verdadero|falso</returns>
        bool Exists();
        /// <summary>
        /// listan todos los registros
        /// </summary>
        /// <returns>devuelve un datatable</returns>
        System.Data.DataTable List();
        /// <summary>
        /// modifica el objeto
        /// </summary>
        void Update();
    }
    
}