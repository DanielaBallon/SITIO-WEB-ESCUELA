using System;
using System.Data;
using BASICA;

namespace BUSSINESSCHOOL
{
    internal partial class Singleton : ISingletonCarrera
    {
        public ISingletonCarrera ISC => this; //referencia publica a la intancia actual oara acceder a la implementacion de IsingletonCarrera desde afuera de la clase
        #region ISingletonCarrera
        void IGenericSingleton<Carrera>.Add(Carrera Data)
        {
            if (Data.SiglaExists()) throw new Exception("Error ya existe otra carrera con la misma sigla");
            if (Data.NameExists()) throw new Exception("Error ya existe otra carrera con el mismo nombre");
            IConnection.CreateCommand("Carreras_Insert", "Carrera");
            IConnection.AddVarchar("Nombre", 40, Data.Nombre);
            IConnection.AddVarchar("Sigla", 10, Data.Sigla);
            IConnection.AddInt("Duracion", Data.Duracion);
            IConnection.AddVarchar("Titulo", 40, Data.Titulo);
            IConnection.AddVarchar("Estado", 10, Data.Estado);
            Data.ID = IConnection.Insert();
            IIMage.Add(Data.Fu, Data.MakeData);
            IIMage.Add(Data.FUPdf, Data.MakeDataPDF);
        }
        void IGenericSingleton<Carrera>.Modify(Carrera Data)
        {
            if (Data.SiglaExists()) throw new Exception("Error ya existe otra carrera con la misma sigla");
            if (Data.NameExists()) throw new Exception("Error ya existe otra carrera con el mismo nombre");
            IConnection.CreateCommand("Carreras_Update", "Carrera");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddVarchar("Sigla", 10, Data.Sigla);
            IConnection.AddVarchar("Nombre", 40, Data.Nombre);
            IConnection.AddInt("Duracion", Data.Duracion);
            IConnection.AddVarchar("Titulo", 40, Data.Titulo);
            IConnection.AddVarchar("Estado", 10, Data.Estado);
            IConnection.Update();
            IIMage.Add(Data.Fu, Data.MakeData);
            IIMage.Add(Data.FUPdf, Data.MakeDataPDF);
        }
        void IGenericSingleton<Carrera>.Erase(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_Delete", "Carrera");
            IConnection.AddInt("ID", Data.ID);
            IConnection.Delete();
            IIMage.Erase(Data.MakeData);
            IIMage.Erase(Data.MakeDataPDF);
        }
        string IGenericSingleton<Carrera>.Find(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_Find", "Carrera");
            IConnection.AddInt("ID", Data.ID);
            DataRow Dr = IConnection.Find();
            return ISC.MakeJson(Dr, Data);
        }

        string ISingletonCarrera.FindBySigla(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_FindBySigla", "Carrera");
            IConnection.AddVarchar("Sigla", 10, Data.Sigla);
            DataRow Dr = IConnection.Find();
            return ISC.MakeJson(Dr, Data);
        }
        string ISingletonCarrera.List(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_List", "Carrera");
            IConnection.AddVarchar("Estado", 10, Data.Estado);
            DataTable Dt = IConnection.List();
            return IListToTable.TableToJson<Carrera>(Dt, ISC);
        }
        bool ISingletonCarrera.NameExists(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_NameExists", "Carrera");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddVarchar("Nombre", 40, Data.Nombre);
            return IConnection.Exists();
        } 
        bool ISingletonCarrera.SiglaExists(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_SiglaExists", "Carrera");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddVarchar("Sigla", 10, Data.Sigla);
            return IConnection.Exists();
        }

        string IGenericSingleton<Carrera>.MakeJson(DataRow Dr, Carrera Data)
        {
            string Json = "{}"; // objeto Json Vacio 
            string s = "ID"; //nombre de la clave
            Data.ID = int.Parse(Dr[s].ToString()); // Dr[s] es de tipo Objet por eso lo convertimos a cadena 
            Json = IJson.addObject(Json, s, Data.ID.ToString()); // IJson es intancia 
            s = "Nombre";

            Data.Nombre = Dr[s].ToString();
            Json = IJson.addObject(Json, s, Data.Nombre);

            s = "Duracion";
            Data.Duracion = int.Parse(Dr[s].ToString());
            Json = IJson.addObject(Json, s, Data.Duracion.ToString());

            s = "Sigla";
            Data.Sigla = Dr[s].ToString();
            Json = IJson.addObject(Json, s, Data.Sigla);

            s = "Titulo";
            Data.Titulo = Dr[s].ToString();
            Json = IJson.addObject(Json, s, Data.Titulo);


            s = "Estado";
            Data.Estado = Dr[s].ToString();
            Json = IJson.addObject(Json, s, Data.Estado);

            string URL = IIMage.URL(Data.MakeData);
            Json = IJson.addObject(Json, "URL", URL);
            
            string URLPDF = IIMage.URL(Data.MakeDataPDF);
            Json = IJson.addObject(Json, "URLPDF", URLPDF);
            return Json;
        }
        #endregion
    }
}
