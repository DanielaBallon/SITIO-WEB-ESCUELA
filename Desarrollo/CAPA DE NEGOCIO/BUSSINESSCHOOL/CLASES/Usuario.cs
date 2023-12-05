using System;
using System.Web;

namespace BUSSINESSCHOOL
{
    public class Usuario : IUsuario 
    {
        internal Singleton S { get => Singleton.GetInstance; } //obtengo la instancia de Singleton
        public int ID { get ; set; }    //implementacion implicita, dado que es publico

        public string Nombre { get ; set; }
        public int Dni { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNac { get; set; }
        public string MakeFecha => FechaNac.Year.ToString() + "-" + FechaNac.Month.ToString() + "-" + FechaNac.Day.ToString() + "-";
       
        public string Mail { get ; set; }
        public string Telefono { get; set; }
        public string Password { get; set; }
        
        // heredato de la Interfaz ABMFIMG
        public string DirBase => "IMAGENES";
        public string Directory => "USUARIOS";
        public string Prefix => "USUARIO";
        public string Extension { get ; set; }
        public HttpPostedFile Fu { get ; set; }
        public string MakeData => ID + ";" + DirBase + ";" + Directory + ";" + Prefix + ";" + "jpg";

        //-----------Metodos----------

        public void Add()
        {
            S.ISU.Add(this);
        }
        public bool DniExists()
        {
            return S.ISU.DniExists(this);
        }
        public void Erase()
        {
            S.ISU.Erase(this);
        }
        public string Find()
        {
            return S.ISU.Find(this);
        }
        public string FindByDni()
        {
            return S.ISU.FindByDni(this);
        }
        public string FindByMail()
        {
            return S.ISU.FindByMail(this);
        }
        public string FindByMailAndDni()
        {
            return S.ISU.FindByMailAndDni(this);
        }
        public string List()
        {
            return S.ISU.List(this);
        }
        public string Login()
        {
            return S.ISU.Login(this);
        }
        public bool MailExists()
        {
            return S.ISU.MailExists(this);
        }
        public void Modify()
        {
            S.ISU.Modify(this);
        }
        
    }
}
