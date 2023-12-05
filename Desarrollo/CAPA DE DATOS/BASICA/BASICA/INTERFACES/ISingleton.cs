

namespace BASICA
{
    public interface ISingleton
    {
        IIMage IIm { get; }
        IHashing IHash { get; }
        IJson Json { get; }
        string TableToJson<T>(System.Data.DataTable Dt, IGenericSingleton<T> IGS); 
      
        IConnection IC { get; }
        System.Collections.Generic.List<T> TableToList<T>(System.Data.DataTable Dt, IGenericSingleton<T> IGS);
    }
}
