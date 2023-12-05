using BASICA;
using System.Web;

namespace BUSSINESSCHOOL
{
    public interface ICarrera:IABMFIMG
    {
        #region DataContract
        string Sigla { get; set; }  
        string Nombre { get; set; }
        string Titulo   { get; set; }   
        int Duracion { get; set; }
        string Estado { get; set; }
        HttpPostedFile FUPdf { get; set; }
        #endregion
        #region MethodContract
        bool NameExists();
        bool SiglaExists();
        string List();
        string FindBySigla();
        #endregion
    }
}
