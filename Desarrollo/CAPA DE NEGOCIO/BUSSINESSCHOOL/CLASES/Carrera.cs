using System.Web;

namespace BUSSINESSCHOOL
{
    public class Carrera : ICarrera
    {
        
        internal Singleton S => Singleton.GetInstance;
        #region DataContract
        public string Sigla { get; set; }
        public string Nombre { get ; set ; }
        public string Titulo { get ; set ; }
        public int Duracion { get ; set ; }
        public string Estado { get ; set ; }
        public HttpPostedFile FUPdf { get ; set ; }

        
        public string DirBase => "IMAGENES";
        public string Directory => "CARRERAS";
        public string Prefix => "CARRERA";
        public HttpPostedFile Fu { get; set; }
        public int ID { get; set; }

        public string Extension { get ; set ; }
       
        public string MakeData => ID + ";" + DirBase + ";" + Directory + ";" + Prefix + ";" + "jpg";
        public string MakeDataPDF => ID + ";" + DirBase + ";" + Directory + ";" + Prefix + ";" + "pdf";
        #endregion
        #region MethodContract
        public void Add() => S.ISC.Add(this);// this: argumento que hace referencia a la instancia actual de la clase Carrera
        public void Erase() => S.ISC.Erase(this);
        public string Find() => S.ISC.Find(this);
        public string FindBySigla() => S.ISC.FindBySigla(this);
        public string List() => S.ISC.List(this);
        public void Modify() => S.ISC.Modify(this);
        public bool NameExists() => S.ISC.NameExists(this);
        public bool SiglaExists() => S.ISC.SiglaExists(this);
        #endregion
    }
}
