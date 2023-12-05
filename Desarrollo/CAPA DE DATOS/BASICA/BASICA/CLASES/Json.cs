
using System.Data;
namespace BASICA
{
    public class Json : IJson
    {
        string Q = "\""; // Se declara y se inicializa una cadena que contiene el carácter de comillas dobles.

        public string addObject(string parent, string name, string value)
        {
            string Sufix = ""; // Se declara una variable para almacenar el sufijo que cerrará el objeto o la matriz JSON.

            if (parent.StartsWith("{")) // Comprueba si la cadena de entrada comienza con '{' para identificar un objeto JSON.
            {
                Sufix = "}"; // Si es un objeto JSON, el sufijo debe ser '}'.
            }

            if (!value.StartsWith("[") && !value.StartsWith("{")) // Comprueba si el valor no es una matriz ni un objeto JSON.
            {
                value = Q + value + Q; // Si no es una matriz ni un objeto, se envuelve el valor entre comillas dobles.Para asegurar que cumpla cn la estructura correcta JSON
            }

            if (parent.StartsWith("[")) // Comprueba si la cadena de entrada comienza con '[' para identificar una matriz JSON.
            {
                Sufix = "]"; // Si es una matriz JSON, el sufijo debe ser ']'.
            }

            // Concatena el nombre, los dos puntos, el valor y el sufijo (si corresponde) para formar un nuevo par clave-valor en JSON.
            name = Q + name + Q + ":" + value + Sufix;

            if (parent != "{}" && parent != "[]") // Comprueba si el objeto o matriz JSON no está vacío.
            {
                name = "," + name; // Agrega una coma antes del nuevo par clave-valor si el objeto o matriz no está vacío.
            }

            // Reemplaza el último carácter (coma o llave/Corchete) en la cadena de entrada con el nuevo par clave-valor.
            return parent.Remove(parent.Length - 1) + name;
        }

        public string json(DataRow Dr) // genera una representacion JSON de la fila y sus datos
        {
            string Json = "{"; // Inicializa una cadena llamada "Json" con una llave de apertura para comenzar la representación JSON.
            for (int i = 0; i < Dr.Table.Columns.Count; i++) // Inicia un bucle que recorre todas las columnas de la fila.
            {
                Json += Q + Dr.Table.Columns[i].ColumnName + Q + ":" + Q + Dr[i] + Q + ","; // Agrega al JSON el nombre de la columna, seguido de dos puntos (":") y el valor de la celda.
            }
            Json = Json.Remove(Json.Length - 1) + "}"; // Elimina la coma extra al final del JSON y cierra la representación JSON con una llave de cierre.
            return Json; // Devuelve la cadena JSON resultante.
        }

    }
}
/*Este método se utiliza para agregar nuevos elementos 
 (pares clave-valor) a objetos JSON o elementos a matrices JSON, manteniendo la estructura JSON correcta.*/
//parent: puede ser una cadena JSON o una MatrizJson 
// Entonces primero se comprueba que clase de JSON 
// Las cadenas se utilizan para representar valores individuales o propiedades de OBJETO JSON 
// Las matrices  se utilizan para almacenar listas ordenadas de valores, que pueden ser de cualquier tipo de datos JSON.
