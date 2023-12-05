
using System.Collections.Generic;
using System.Data;

namespace BASICA
{ 
    public class ListToTable : IListToTable
    {
        public string TableToJson<T>(DataTable Dt, IGenericSingleton<T> Igs) where T : new()
        {
            if (Dt.Rows.Count == 0) return "[]";
            string Json = "[";
            foreach (DataRow Dr in Dt.Rows) { Json += Igs.MakeJson(Dr, new T()) + ","; } // DataRow: Una fila dentro del Dt.Rows (coleccion de filas)
            //recorre cada fila (Dr) de la tabla DT.
            // En cada iteracción del se implementa el metodo MakeJson del objeto Igs que toma como arumentos 
            //(fila actural(Dr y Crea una nueva instancia de la clase genérica T,)


            return Json.Remove(Json.Length-1)+"]";//elimina la ultima coma agregada y agrega un corchete de cierre
    }
        public IList<T> TableToList<T>(DataTable Dt, IGenericSingleton<T> Igs) where T : new()
        {
            IList<T> IL = new List<T>(); // nueva lista generica (T) que almacenara los objetos de tipo T proveniente de las filas de la tabla
            foreach (DataRow Dr in Dt.Rows)
            {
                T t = new T(); // instancia de la clase genérica T 
                Igs.MakeJson(Dr, t); //  método MakeJson del objeto Igs con los datos de la fila actual y el objeto t para llenar
                IL.Add(t); // luego de de ser llenando (t) se agrega a la lista 
            }
        return IL;
        }
    }
}