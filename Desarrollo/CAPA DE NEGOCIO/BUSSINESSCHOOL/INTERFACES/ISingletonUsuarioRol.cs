
using BASICA;

namespace BUSSINESSCHOOL
{
    interface ISingletonUsuarioRol:IGenericSingleton<UsuarioRol>
    {
        string ListRolesByUsuario(UsuarioRol Data);
       
    }
}
