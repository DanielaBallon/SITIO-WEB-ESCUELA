const $$Form = function () {
    const ROLES = [
        "ADMINISTRADOR",
        "DIRECTOR DE ESTUDIOS",
        "PROFESOR",
        "PRECEPTOR",
        "ALUMNO",
        "INSCRIPTO",
        "EXCLUIDO",
    ];
    this.logout = function () {
        const Change = function () {
            Rol = roles.value;
            console.log(Rol);
            $n.Init(Rol);
        };
        const Submit = function () {
            Usuario = undefined;
            Rol = undefined;
            $n.Init();
            HomeIMG();
            return false;
        };
        const MakeRoles = function () {
            for (var i = 0; i < Usuario.Roles.length; i++) {
                let rol = Usuario.Roles[i];
                $dc.option(roles, rol, rol);
            }
            Change();
        };
        Home();
        let f = $dc.form("Usuario ", "Salir");
        f.className = "w60 l8 ";
        let roles = $dc.select("ROL");
        MakeRoles();
        roles.onchange = Change;
        Reset.style.display = "none";
        $dc.img(Foot, Usuario.URL).className = "Foto";
        Foot.className = "logout";
        Cform.className = "logout";
        f.onsubmit = Submit;
    };

    this.login = function () {
        const Fload = function (res) {
            if (res.includes("Error")) {
                alert(res);
                return;
            } else {
                Usuario = JSON.parse(res);

                $f.logout();
            }
        };

        Home();
        let f = $dc.formImg("ingresar al sistema", "ingresar", Fload);
        f.className = "w40";
        let Mail = $dc.inputMail("Mail");
        Mail.name = "Mail";
        Mail.value = "admin@mail.com";

        let Password = $dc.inputPassword("Contraseña");
        Password.name = "Password";
        Password.value = "admin";
        $dc.forgot(f).onclick = $f.forgot;

        $dc.inputHidden("accion", "LOGIN");
    };

    this.ABMUsuarios = function () {
        const ListarUsuarios = function () {
            const Res = Post("accion=LISTUSUARIOS");
            const List = JSON.parse(Res);
            const H = [
                "ID",
                "Nombre",
                "dni",
                "mail",
                "Direccion",
                "Foto",
                "modificar",
                "eliminar",
            ];
            const Frow = function (tr, usuario) {
                tr.childNodes[0].innerText = usuario.ID;
                tr.childNodes[1].innerText = usuario.Nombre.toUpperCase();
                tr.childNodes[2].innerText = usuario.Dni;
                tr.childNodes[3].innerText = usuario.Mail;
                tr.childNodes[4].innerText = usuario.Direccion.toUpperCase();
                $dc.img(tr.childNodes[5], usuario.URL).style.height = "3rem";
                $dt.TdControl(
                    tr.childNodes[6],
                    "modificar",
                    "#333",
                    "#fff",
                    function () {
                        const Res = Post("accion=ObtenerUserRol&ID=" + usuario.ID);
                        const User = JSON.parse(Res);
                        $f.ModUsuarioRol(User);
                    }
                );
                $dt.TdControl(
                    tr.childNodes[7],
                    "eliminar",
                    "#933",
                    "#fff",
                    function () {
                        let res = Post("accion=DELETUSUARIO&ID=" + usuario.ID);
                        if (res !== "OK") {
                            alert(res);

                            return;
                        }
                        $f.ABMUsuarios();
                    }
                );
            };
            $dt.Table(H, List, 4, Frow);
        };
        const Fload = function (res) {
            if (res !== "OK") {
                alert(res);
                return;
            }

            $f.ABMUsuarios();
        };

        Home();
        let f = $dc.formImg("ABM Usuarios", "Agregar", Fload);
        f.className = "w60 l18";

        let nombre = $dc.inputText("nombre");
        nombre.name = "Nombre";

        let mail = $dc.inputMail("mail");
        mail.name = "Mail";

        let dni = $dc.inputNumber("dni");
        dni.name = "Dni";

        let direccion = $dc.inputText("direccion");
        direccion.name = "Direccion";

        let fechaNac = $dc.inputDate("Fecha de nacimiento");
        fechaNac.name = "Fecha";

        let telefono = $dc.inputText("telefono");
        telefono.name = "Telefono";

        $dc.inputHidden("Password", Usuario.Dni);

        $dc.inputHidden("accion", "ADDUSUARIO");

        ListarUsuarios();
    };

    this.ModUsuarioRol = function (user) {
        const Fload = function (res) {
            if (res !== "OK") {
                alert(res);
                return;
            }

            $f.ABMUsuarios();
        };

        const MakeRols = function (User) {
            const RolExists = function (ROL) {
                for (var i = 0; i < User.Roles.length; i++) {
                    if (User.Roles[i] === ROL) return true; // user.Roles: roles ya asignados al usuario
                }
                return false;
            };
            rolPosible.innerHTML = "";
            roles.innerHTML = "";
            for (var i = 0; i < ROLES.length; i++) {
                if (!RolExists(ROLES[i])) {
                    $dc.option(rolPosible, ROLES[i], ROLES[i]);
                }
            }
            for (var j = 0; j < ROLES.length; j++) {
                if (RolExists(ROLES[j])) $dc.option(roles, ROLES[j], ROLES[j]);
            }
        };

        const AddRol = function (user) {
            // Obtener el select "Roles Posibles"
            const rolPosibles = $d.id("rolPosible");

            // Obtener el valor del rol seleccionado por el usuario
            const indiceSeleccionado = rolPosibles.selectedIndex;
            const rolSeleccionadoValue = rolPosibles.options[indiceSeleccionado].value;

            let res = Post("accion=ADDROL&UserID=" + user.ID + "&Rol=" + rolSeleccionadoValue);
            let UsuariosSelect = JSON.parse(res);
            MakeRols(UsuariosSelect);
          

        };

        const EraseRol = function () {
            const RolesDelUsuario = $d.id("roles");

            // Obtener el valor del rol seleccionado por el usuario
            const indiceSeleccionado = RolesDelUsuario.selectedIndex;
            const rolSeleccionadoValue = RolesDelUsuario.options[indiceSeleccionado].value;

            let res = Post("accion=DELETEROL&UserID=" + user.ID + "&Rol=" + rolSeleccionadoValue);
            let UsuariosSelect = JSON.parse(res);
            MakeRols(UsuariosSelect);



        };
    // #region Form
        Home();
        let f = $dc.formImg("Modifica " + user.Nombre, "modificar", Fload);
        f.className = "w60 l24";
        $dc.inputHidden("ID", user.ID);
        let nombre = $dc.inputText("nombre");
        nombre.name = "Nombre";
        nombre.value = user.Nombre;

        let dni = $dc.inputNumber("dni");
        dni.name = "Dni";
        dni.value = user.Dni;

        let mail = $dc.inputMail("mail");
        mail.name = "Mail";
        mail.value = user.Mail;

        let direccion = $dc.inputText("direccion");
        direccion.name = "Direccion";
        direccion.value = user.Direccion;

        let fechaNac = $dc.inputDate("Fecha de nacimiento");
        fechaNac.name = "Fecha";
        fechaNac.value = user.FechaNac;

        let telefono = $dc.inputText("Teléfono");
        telefono.name = "Telefono";
        telefono.value = user.Telefono;

        let rolPosible = $dc.select("Roles posibles"); 
        rolPosible.id = "rolPosible";
        rolPosible.className = "dblButton";

        let roles = $dc.select("Roles"); 
        roles.id = "roles";
        MakeRols(user);
        let double = $dc.doubleButton();
        double[0].innerText = "AGREGAR ROL";
        double[1].innerText = "QUITAR ROL";
        double[0].onclick = function () {
            AddRol(user); 
        };
        double[1].onclick = function () {

            EraseRol(user);
        };

//#endregion
        $dc.inputHidden("accion", "MODIFYUSERWITHROLES");
    };

    this.perfil = function () {
        const Fload = function (res) {
            if (res.includes("Error")) {
                alert(res);
                return;
            } else {          

                $f.perfil();
            }
        };

      
        Home();
        let f = $dc.formImg("Perfil " + Usuario.Nombre, "modificar", Fload);
        f.className = "w60 l16";
        $dc.inputHidden("ID", Usuario.ID);
        let nombre = $dc.inputText("nombre");
        nombre.name = "Nombre";
        nombre.value = Usuario.Nombre;

        let direccion = $dc.inputText("direccion");
        direccion.name = "Direccion";
        direccion.value = Usuario.Direccion;

        let telefono = $dc.inputNumber("Telefono");
        telefono.name = "Telefono";
        telefono.value = Usuario.Telefono;

        let password = $dc.inputsPasswordConfirm();
        password.name = "Password";

        $dc.inputFileImg("Foto", "Foto");
        $dc.inputHidden("accion", "MODIFYUSUARIO");
    };

    this.findByDni = function () {
        const Fload = function (res) {
            const User = JSON.parse(res);
            $f.ModUsuarioRol(User);
        };
        Home();
        let f = $dc.formImg("Buscar Usuario por DNI ", "Buscar", Fload);
        f.className = "w60 l8";

        let nombre = $dc.inputText("DNI");
        nombre.name = "Dni";

        $dc.inputHidden("accion", "FindUserRolByDni");
    };

    this.findByMail = function () {
        const Fload = function (res) {
            const User = JSON.parse(res);
            $f.ModUsuarioRol(User);
        };
        Home();
        let f = $dc.formImg("Buscar Usuario por Mail ", "Buscar", Fload);
        f.className = "w60 l8";

        let Mail = $dc.inputMail("Mail");
        Mail.name = "Mail";

        $dc.inputHidden("accion", "FindUserRolByMail");
    };

    this.forgot = function () {
        const Fload = function (res) {
            if (res !== "OK") {
                alert(res);
                return;
            }
            alert("Se restablecio correctamente su contraseña con valor de su DNI");
            $f.login();
        };

        Home();
        let f = $dc.formImg("ingresar al sistema", "ingresar", Fload);
        f.className = "w60";
        let Mail = $dc.inputMail("Mail");
        Mail.name = "Mail";
        let Dni = $dc.inputNumber("Dni");
        Dni.name = "Dni";
        $dc.inputHidden("accion", "RecoveryPassword");
    };
};
const $f = new $$Form();

