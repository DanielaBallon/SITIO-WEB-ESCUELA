using BASICA;

namespace BUSSINESSCHOOL
{
    public interface IUsuario: IABMFIMG
    {
        //Data contract
        string Nombre { get; set; }
        int Dni { get; set; }
        string Mail { get; set; }
        string Password { get; set; }
        //Method Contract
        bool DniExists();
        bool MailExists();
        string FindByMail();
        string FindByDni();
        string FindByMailAndDni();
        string Login();
        string List();

        
    }
}
