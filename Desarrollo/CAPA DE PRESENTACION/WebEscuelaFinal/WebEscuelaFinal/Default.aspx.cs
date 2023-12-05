using System;
using BUSSINESSCHOOL;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["accion"] == null) return;
        switch (Request["accion"])
        {
            case "LOGIN": Login(); break;
            case "LISTUSUARIOS": ListUsuarios(); break;
            case "ADDUSUARIO": AddUsuario(); break;
            case "ADDROL": AddRol(); break;
            case "DELETEROL": DeleteRol(); break;
            case "MODIFYUSERWITHROLES": ModifyUserWithRoles(); break;
            case "MODIFYUSUARIO": ModificarUsuario(); break;
            case "ObtenerUserRol": GetUserRol(); break;
            case "DELETUSUARIO": DeleteUsuario(); break;
            case "FindUserRolByDni": FindUserRolByDni(); break;
            case "FindUserRolByMail": FindUserRolByMail(); break;
            case "RecoveryPassword": RecoveryPassword(); break;
            //CARRERAS  
            case "ADDCARRERA": AddCarrera(); break;
            case "LISTCARRERAS": ListCarrera(); break;
            case "MODIFYCARRERA": ModifyCarrera(); break;
            case "OBTERNERCARRERA": GetCarrera();break;
            case "DELETECARRERA": DeleteCarrera();break;    
                


        }
    }

    //USUARIO
    private void Login()
    {
        UsuarioRol UR = new UsuarioRol()
        {
            Usuario = new Usuario()
            {
                Mail = Request["Mail"],
                Password = Request["Password"],
            }
        };
        
        try
        {
            UR.Usuario.Login();
            Response.Write(UR.ListRolesByUsuario());

        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }
    private void ModificarUsuario()
    {
        try
        {
            Usuario U = new Usuario();
                         
            U.ID = int.Parse(Request["ID"]);
            U.Find();
            U.Nombre = Request["Nombre"];
            U.Direccion = Request["Direccion"];
            U.Telefono = Request["Telefono"];
            U.Password = Request["Password"];
            if (Request.Files.Count > 0) U.Fu = Request.Files[0];
            U.Modify();
        
            UsuarioRol usuarioRol = new UsuarioRol();
            usuarioRol.Usuario = U;
            Response.Write(usuarioRol.ListRolesByUsuario());
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }
    private void AddUsuario()
    {

        Usuario U = new Usuario();
        U.Nombre = Request["Nombre"];
        U.Mail = Request["Mail"];
        U.Dni = int.Parse(Request["Dni"]);
        U.Direccion = Request["Direccion"];
        U.FechaNac = DateTime.Parse(Request["Fecha"]);
        U.Telefono = Request["Telefono"];
        U.Password = Request["Dni"].ToString(); 

        UsuarioRol usuarioRol = new UsuarioRol()
        {
            Usuario = U,
        };
        try
        {
            U.Add();
           // Response.Write(usuarioRol.ListRolesByUsuario());
            Response.Write("OK");
        }
        catch (Exception er)
        {

            Response.Write(er.Message);
        }
    }

    private void DeleteRol()
    {
        UsuarioRol UR = new UsuarioRol();
        UR.Usuario = new Usuario();
        UR.Usuario.ID = int.Parse(Request["UserID"]);
        UR.Rol = Request["Rol"];
        UR.Erase();

        Response.Write(UR.ListRolesByUsuario());
    }
    private void AddRol()
    {
        UsuarioRol UR = new UsuarioRol();
        UR.Usuario = new Usuario();
        UR.Usuario.ID = int.Parse(Request["UserID"]);
        UR.Rol = Request["Rol"];
        UR.Add();
        Response.Write(UR.ListRolesByUsuario());
    }
    

    private void ListUsuarios()
    {
        try
        {
            Response.Write(new Usuario().List());
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }
    private void ModifyUserWithRoles()


    {
        Usuario U = new Usuario

        {
            ID = int.Parse(Request["ID"]),
            Nombre = Request["Nombre"],
            Mail = Request["Mail"],
            Dni = int.Parse(Request["Dni"]),
            Direccion = Request["Direccion"],
            FechaNac = DateTime.Parse(Request["Fecha"]),
            Telefono = Request["Telefono"],
            
        };

        if (Request["Password"] != null)
        {
            U.Password = Request["Password"];
        }
        else
            U.Password = "";
        try
        {
            U.Modify();
            Response.Write("OK");
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }
    
    private void GetUserRol()
    {
        try
        {
            UsuarioRol UR = new UsuarioRol()
            {
                Usuario = new Usuario()
                {
                    ID = int.Parse(Request["ID"]),
                }
            };
            Response.Write(UR.ListRolesByUsuario());
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }
    private void DeleteUsuario()
    {
        Usuario U = new Usuario()
        {
            ID = int.Parse(Request["ID"])
        };
        try
        {
            U.Erase();
            Response.Write("OK");
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }


    private void FindUserRolByDni()
    {
        UsuarioRol UR = new UsuarioRol()
        {
            Usuario = new Usuario()
            {
                Dni = int.Parse(Request["Dni"])
            },
        };
        try
        {
            UR.Usuario.FindByDni();
            Response.Write(UR.ListRolesByUsuario());
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }

    }
    private void FindUserRolByMail()
    {
        UsuarioRol UR = new UsuarioRol()
        {
            Usuario = new Usuario()
            {
                Mail = Request["Mail"]
            },
        };
        try
        {
            UR.Usuario.FindByMail();
            Response.Write(UR.ListRolesByUsuario());
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }
    private void RecoveryPassword()
    {
        Usuario U = new Usuario()
        {
            Mail = Request["Mail"],
            Dni = int.Parse(Request["Dni"])
        };
        try
        {
            U.FindByMailAndDni(); 
            U.Password = U.Dni.ToString();
            U.Modify();
            Response.Write("OK");
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }

    //CARRERAS
    private void ModifyCarrera()
    {
        Carrera c = new Carrera()
        {
            Nombre = Request["Nombre"],
            Duracion = int.Parse(Request["Duracion"]),
            Titulo = Request["Titulo"],
            Estado = Request["Estado"],
            Sigla = Request["Sigla"],
            ID = int.Parse(Request["ID"])
        };
        if (Request.Files.Count > 0)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                if (Request.Files[i].FileName.EndsWith("pdf"))
                {
                    c.FUPdf = Request.Files[i];
                }
                else if (Request.Files[i].FileName.EndsWith("jpg"))
                {
                    c.Fu = Request.Files[i];
                }
            }
        }
        try
        {
            c.Modify();
            Response.Write("OK");
        }
        catch (Exception err)
        {
            Response.Write(err.Message);

        }
    }

    private void ListCarrera()
    {
        try
        {
            Carrera c = new Carrera();
            c.Estado = "ACTIVO";
            Response.Write(c.List());
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }

    private void AddCarrera()
    {
        Carrera c = new Carrera()
        {
            Nombre = Request["Nombre"],
            Titulo = Request["Titulo"],
            Sigla = Request["Sigla"],
            Estado = Request["Estado"],
            Duracion = int.Parse(Request["Duracion"])
        };

        if (Request.Files.Count > 0)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                if (Request.Files[i].FileName.EndsWith("pdf"))
                {
                    c.FUPdf = Request.Files[i];
                }
                else if (Request.Files[i].FileName.EndsWith("jpg"))
                {
                    c.Fu = Request.Files[i];
                }
            }

        }
        try
        {
            c.Add();
            Response.Write("OK");
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }



    private void GetCarrera()
    {
        try
        {
            Carrera c = new Carrera()
            {
                Sigla = Request["Sigla"]

            };
               
            
            Response.Write(c.FindBySigla());
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }
    private void DeleteCarrera()
    {
        Carrera c = new Carrera()
        {
            ID = int.Parse(Request["ID"])
        };
        try
        {
            c.Erase();
            Response.Write("OK");
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }
}