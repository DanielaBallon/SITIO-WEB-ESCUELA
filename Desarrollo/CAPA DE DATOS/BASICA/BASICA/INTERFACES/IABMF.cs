
namespace BASICA
{

    public interface IABMF : IID
    {
        /// <summary>
        /// modifica el objeto desde la persistencia
        /// </summary>
        void Modify();
        /// <summary>
        /// persiste un elemento
        /// </summary>
        void Add();
        /// <summary>
        /// Elimina un elemento de la persistencia
        /// </summary>
        void Erase();
        /// <summary>
        /// encuentra un objeto desde la persistencia
        /// </summary>
        /// <returns>
        /// string que representa el objeto en Json
        /// </returns>
        string Find();
    }
}
