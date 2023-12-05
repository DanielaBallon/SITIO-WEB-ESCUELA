using BASICA; 
namespace BussinesTable
{
    public class Dispersor
    {
       public string Dispersar(string data)
        {
            return new Sha().Hash(data);
        }
    }
}
