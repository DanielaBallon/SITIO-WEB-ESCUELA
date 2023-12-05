using System.Data;
using BASICA;

namespace BUSSINESSCHOOL
{
    partial class Singleton : ISingletonUsuarioRol
    {
        public ISingletonUsuarioRol ISUR => this;

        void IGenericSingleton<UsuarioRol>.Add(UsuarioRol Data)
        {
            IConnection.CreateCommand("UsuariosRoles_Insert", "Rol de usuario");
            IConnection.AddInt("IDUsuario", Data.Usuario.ID);
            IConnection.AddVarchar("Rol", 20, Data.Rol);
            Data.ID = IConnection.Insert();
        }
        void IGenericSingleton<UsuarioRol>.Erase(UsuarioRol Data)
        {
            IConnection.CreateCommand("UsuariosRoles_Delete", "Rol de usuario");
            IConnection.AddInt("IDUsuario", Data.Usuario.ID);
            IConnection.AddVarchar("Rol", 20, Data.Rol);
            IConnection.Delete();
        }
        string IGenericSingleton<UsuarioRol>.Find(UsuarioRol Data)
        {
            IConnection.CreateCommand("UsuariosRoles_Find", "Roles de usuario");
            IConnection.AddInt("IDUsuario", Data.Usuario.ID);
            DataRow row = IConnection.Find();
            return ISUR.MakeJson(row,Data);
        }
        string ISingletonUsuarioRol.ListRolesByUsuario(UsuarioRol Data) //ListByUsuario
        {
            IConnection.CreateCommand("UsuariosRoles_ListByUsuario", "Roles de usuario");
            IConnection.AddInt("IDUsuario", Data.Usuario.ID);
            DataTable Dt = IConnection.List();
            string JsonUser = Data.Usuario.Find();
            string Roles = IListToTable.TableToJson(Dt, ISUR);
            return IJson.addObject(Data.Usuario.Find(), "Roles", Roles);
        }
        string IGenericSingleton<UsuarioRol>.MakeJson(DataRow Dr, UsuarioRol Data)
        {
            return "\"" + Dr["Rol"] + "\"";
        }
        void IGenericSingleton<UsuarioRol>.Modify(UsuarioRol Data)
        {
            IConnection.CreateCommand("UsuariosRoles_Update", "rol de usuario");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddInt("IDUsuario", Data.Usuario.ID);
            IConnection.AddVarchar("Rol", 20, Data.Rol);
            IConnection.Update();
        }
    }
}
