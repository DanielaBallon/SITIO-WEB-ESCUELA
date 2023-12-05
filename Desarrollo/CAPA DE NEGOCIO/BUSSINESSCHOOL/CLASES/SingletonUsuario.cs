using System;
using System.Data;
using BASICA;

namespace BUSSINESSCHOOL
{
    internal partial class Singleton : ISingletonUsuario
    {
        public ISingletonUsuario ISU { get => this; } // referecnia al propio singleton pero con la interface singleton usuario. Modificador de acceso publico
        void IGenericSingleton<Usuario>.Add(Usuario Data)
        {
            if (Data.DniExists()) throw new Exception("Existe otro usuario con el mismo Dni");
            if (Data.MailExists()) throw new Exception("Existe otro usuario con el mismo Mail");

            IConnection.CreateCommand("Usuarios_Insert", "Usuario");
            IConnection.AddVarchar("Nombre", 30, Data.Nombre); //los parametros que recibe MyCommand 
            IConnection.AddInt("Dni", Data.Dni);
            IConnection.AddVarchar("Direccion", 50, Data.Direccion);
            IConnection.AddDatetime("FechaNac", Data.FechaNac);
            IConnection.AddVarchar("Mail", 40, Data.Mail);
            IConnection.AddVarchar("Telefono", 15, Data.Telefono);
            Data.Password = IHashing.Hash(Data.Password);
            IConnection.AddVarchar("Password", 40, Data.Password);
            Data.ID = IConnection.Insert(); //devuelve la primera columna de la primera fila, o sea el ID
            IIMage.Add(Data.Fu,Data.MakeData);
        }
        void IGenericSingleton<Usuario>.Erase(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Delete", "Usuarios");
            IConnection.AddInt("ID", Data.ID);
            IConnection.Delete();
            IIMage.Erase(Data.MakeData);
        }
        string IGenericSingleton<Usuario>.Find(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Find", "Usuario");
            IConnection.AddInt("ID", Data.ID);
            DataRow Dr = IConnection.Find();
            return ISU.MakeJson(Dr, Data);
        }
        string IGenericSingleton<Usuario>.MakeJson(DataRow Dr, Usuario Data)
        {
            string Json = "{}";

            string s = "ID";
            Data.ID = int.Parse(Dr[s].ToString());
            Json = IJson.addObject(Json, s, Data.ID.ToString());
            s = "Nombre";
            Data.Nombre = Dr[s].ToString();
            Json = IJson.addObject(Json, s, Data.Nombre);
            s = "Dni";
            Data.Dni = int.Parse(Dr[s].ToString());
            Json = IJson.addObject(Json, s, Data.Dni.ToString());

            s = "Direccion";
            Data.Direccion = Dr[s].ToString();
            Json = IJson.addObject(Json, s, Data.Direccion.ToString());
            s = "FechaNac";
            Data.FechaNac = DateTime.Parse(Dr[s].ToString());
            Json = IJson.addObject(Json, s, Data.FechaNac.ToString("yyyy-MM-dd"));


            s = "Mail";
            Data.Mail = Dr[s].ToString();
            Json = IJson.addObject(Json, s, Data.Mail);

            s = "Telefono";
            Data.Telefono = Dr[s].ToString();
            Json = IJson.addObject(Json, s, Data.Telefono);

            string URL = IIMage.URL(Data.MakeData);
            Json = IJson.addObject(Json, "URL", URL);
            return Json;
        }//cargar el data y creal el JSON
        void IGenericSingleton<Usuario>.Modify(Usuario Data)
        {
            if (Data.DniExists()) throw new Exception("Existe otro usuario con el mismo Dni");
            if (Data.MailExists()) throw new Exception("Existe otro usuario con el mismo Mail");

            IConnection.CreateCommand("Usuarios_Update", "Usuario");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddVarchar("Nombre", 50, Data.Nombre);
            IConnection.AddInt("Dni", Data.Dni);
            IConnection.AddVarchar("Direccion", 50, Data.Direccion);
            IConnection.AddDatetime("FechaNac", Data.FechaNac);
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            IConnection.AddVarchar("Telefono", 15, Data.Telefono);
            if (Data.Password != "")
            {
                Data.Password = IHashing.Hash(Data.Password);
            }
            IConnection.AddVarchar("Password", 64, Data.Password);
            IConnection.Update();

            IIMage.Add(Data.Fu, Data.MakeData);
        }

        bool ISingletonUsuario.MailExists(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_MailExists", "Usuarios");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            return IConnection.Exists();
        }
        bool ISingletonUsuario.DniExists(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_DniExists", "Usuario");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddInt("Dni", Data.Dni);
            return IConnection.Exists();
        }
        string ISingletonUsuario.FindByDni(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_FindByDni", "Usuario");
            IConnection.AddInt("Dni", Data.Dni);
            DataRow dr = IConnection.Find();
            return ISU.MakeJson(dr, Data);
        }
        string ISingletonUsuario.FindByMail(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_FindByMail", "Usuarios");
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            DataRow dr = IConnection.Find();
            return ISU.MakeJson(dr, Data);
        }
        string ISingletonUsuario.FindByMailAndDni(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_FindByMailAndDni", "Usuario");
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            IConnection.AddInt("Dni", Data.Dni);
            DataRow dr = IConnection.Find();
            return ISU.MakeJson(dr, Data);
        }
        string ISingletonUsuario.List(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_List", "Usuario");
            DataTable Dt = IConnection.List();

            return IListToTable.TableToJson(Dt, ISU);
        }
        string ISingletonUsuario.Login(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Login", "Usuario");
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            Data.Password = IHashing.Hash(Data.Password);
            IConnection.AddVarchar("Password", 64, Data.Password);
            DataRow Dr = IConnection.Find();//devuelve un objeto DataRow 1ra fila
            Data.ID = int.Parse(Dr["ID"].ToString());
            return ISU.MakeJson(Dr, Data);
        }

        // implementacion explicita privada, no puedo acceder a los datos ni siquiera desde el mismo objeto
    
   
    }
}
     