
namespace BASICA
{
    public class Dispersor
    {
        public string Dispersar(string data)
        {
            return new Sha().Hash(data);
        }
    }
}
