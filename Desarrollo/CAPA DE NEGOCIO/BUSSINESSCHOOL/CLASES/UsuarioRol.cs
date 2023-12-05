namespace BUSSINESSCHOOL
{
    public class UsuarioRol : IUsuarioROL
    {
        Singleton S = Singleton.GetInstance;

        public Usuario Usuario { get ; set ; }
        public string Rol { get; set; }
        public int ID { get ; set ; }
        public void Add() => S.ISUR.Add(this);
        public void Erase() => S.ISUR.Erase(this);
        public string Find() => S.ISUR.Find(this);
        public string ListRolesByUsuario() => S.ISUR.ListRolesByUsuario(this);
        public void Modify() => S.ISUR.Modify(this);
    }
}
