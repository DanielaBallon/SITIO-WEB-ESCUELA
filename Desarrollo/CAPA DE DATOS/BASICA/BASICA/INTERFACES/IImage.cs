

namespace BASICA
{
    public interface IIMage : IID
    {
        /// <summary>
        /// Agrega o sustituye
        /// una imagen 
        /// en el sistema  web persistente
        /// </summary>
        /// <param name="FU"> archivo de imagen</param>
        /// <param name="Data">
        /// string que contiene 
        /// ID+;+ArchivoBase+;+Directorio+;+Prefijo
        /// </param>
        void Add(System.Web.HttpPostedFile FU, string Data);
        /// <summary>
        /// Elimina un archivo de imagen 
        /// del sistema web persistente
        /// </summary>
        /// <param name="Data">
        /// string que contiene 
        /// ID+;+ArchivoBase+;+Directorio+;+Prefijo
        /// </param>
        void Erase(string Data);
        /// <summary>
        /// Devuelve la Url de la imagen del objeto
        /// </summary>
        /// <param name="Data">
        /// string que contiene 
        /// ID+;+ArchivoBase+;+Directorio+;+Prefijo
        /// </param>
        /// <returns></returns>
        string URL(string Data);
    }
}
