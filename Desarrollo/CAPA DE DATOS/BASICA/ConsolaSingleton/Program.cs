
using BASICA;
namespace ConsolaSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicSingleton BS = BasicSingleton.GetInstance;
            BS.Saludar();
        }
    }
}
