

namespace BASICA
{
    /// <summary>
    /// agrega parametros para 
    /// los store procedures
    /// </summary>
    public interface IParameters
    {
        void AddInt(string name, int value);
        void AddBit(string name, bool value);
        void AddFloat(string name, double value);
        void AddDatetime(string name, System.DateTime value);
        void AddVarchar(string name, int length, string value);
    }
}
//define varios métodos para agregar diferentes tipos de parámetros a un comando SQL. Estos métodos son utilizados para definir 
//los valores de los parámetros que se enviarán cuando se ejecute un procedimiento almacenado en la base de datos.