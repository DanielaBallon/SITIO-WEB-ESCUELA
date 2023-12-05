

namespace BASICA
{ 
    public interface IJson
 {
    /// <summary>
    /// genera un objeto json 
    /// </summary>
    /// <param name="parent">objeto json o tabla json</param>
    /// <param name="name">Nombre de objeto</param>
    /// <param name="value">
    /// string valor que  puede ser 
    /// objeto {}
    /// tabla []
    /// valor
    /// </param>
    /// <returns></returns>
    string addObject(string parent, string name, string value);
    string json(System.Data.DataRow Dr);
 }
}
