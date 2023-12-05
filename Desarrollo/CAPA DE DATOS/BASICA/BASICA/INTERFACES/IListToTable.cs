
using System.Collections.Generic;
namespace BASICA
{    
    public interface IListToTable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">clase con constructor sin parámetros (por defecto)</typeparam>
        /// <param name="Dt">Tabla con una lista de objetos</param>
        /// <param name="Igs">Interface heredera de IgenericSingleton<T></param>
        /// <returns>IList<T></returns>
        IList<T> TableToList<T>(System.Data.DataTable Dt, IGenericSingleton<T> Igs) where T : new();
        /// <summary>
        /// Devuelve un arreglo de objetos Json del contenido de una tabla
        /// </summary>
        /// <typeparam name="T">clase con constructor sin parámetros (por defecto)</typeparam>
        /// <param name="Dt">Tabla con una lista de objetos</param>
        /// <param name="Igs">Interface heredera de IgenericSingleton<T></param>
        /// <returns></returns>       
        string TableToJson<T>(System.Data.DataTable Dt, IGenericSingleton<T> Igs) where T : new();

    }
 
}