using System;
using System.Collections.Generic;


namespace BASICA
{
    public interface IABMFTable : IABMF
    {
        /// <summary>
        /// produce una lista en json de la tabla
        /// </summary>
        /// <returns>lista json de objetos contenidos en la tabla</returns>
        string List();
        /// <summary>
        /// obtiene la direccion del servidor del esquma xml
        /// </summary>
        string PathSchema { get; }
        /// <summary>
        /// obtiene la direccion del servidor 
        /// de los datos de la tabla 
        /// </summary>
        string Path { get; }
        /// <summary>
        /// si no existe el esquema 
        /// crea una tabla y guarda el esquema
        /// y los datos
        /// </summary>
        void Create();
        /// <summary>
        /// persiste una Tabla
        /// </summary>
        /// <param name="Dt">tabla a persistir</param>
        void Save(System.Data.DataTable Dt);
        /// <summary>
        /// crea una Tabla
        /// la carga una  del sistema persistente
        /// </summary>
        /// <returns>Devuelve la tabla</returns>
        System.Data.DataTable Load();
        /// <summary>
        /// apunta a un objeto imagen
        /// </summary>
        IIMage IIM { get; }
    }
}
