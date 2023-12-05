

namespace BASICA
{
    public interface IGenericSingleton<T>
    {
        void Add(T Data); //parametro: objeto generico T (Data)
        void Erase(T Data);
        void Modify(T Data);
        string Find(T Data);
        string MakeJson(System.Data.DataRow Dr, T Data);//parametro DataRow(fila) y objeto generico T (Data) 
    }
}
