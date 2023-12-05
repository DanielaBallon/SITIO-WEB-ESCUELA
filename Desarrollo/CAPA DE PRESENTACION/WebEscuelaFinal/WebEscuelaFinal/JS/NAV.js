const $$Nav = function () {
    //FUNCTIONS
    const Anonimous = function () {
        $dn.clear();
        $dn.makeButton("Inicio", HomeImg);
        $dn.makeButton("Carreras", $c.ListCarreras);
        $dn.makeButton("Noticias", "");
        $dn.makeButtonLogin("LOGIN", $f.login);
    };
    const Administrador = function () {
        $dn.clear();
        $dn.makeButton("Inicio", HomeImg);
        $dn.makeButton("perfil", $f.perfil);
        $dn.makeDropdownButton("funciones",
            ["abm usuario",
                "mod. usuario por Dni",
                "mod. usuario por mail",
                "abm carreras"],
            [$f.ABMUsuarios,
            $f.findByDni,
            $f.findByMail,
            $c.ABMCarreras 
            ]
        );
        $dn.makeButtonLogin(Usuario.Nombre.toUpperCase(), $f.logout);
    };
    const DirEstudios = function () {
        $dn.clear();
        $dn.makeButton("Inicio", HomeImg);
        $dn.makeButton("perfil", $f.perfil);
        $dn.makeDropdownButton("funciones",
            ["abm materias",
                "abm correlativas",
                "abm cursadas"],
            ["",
                "",
                ""
            ]);
        $dn.makeButtonLogin(Usuario.Nombre.toUpperCase(), $f.logout);
    };
    const Preceptor = function () {
        $dn.clear();
        $dn.makeButton("Inicio", HomeImg);
        $dn.makeButton("perfil", $f.perfil);
        $dn.makeDropdownButton("funciones",
            ["Alta de alumno",
                "Controlar",
                "abm cursadas"],
            ["",
                "",
                ""
            ]);
        $dn.makeButtonLogin(Usuario.Nombre.toUpperCase(), $f.logout);
    };
    const Alumno = function () {
        $dn.clear();
        $dn.makeButton("Inicio", HomeImg);
        $dn.makeButton("perfil", $f.perfil);
        $dn.makeDropdownButton("funciones",
            ["mis materias",
                "Incribirse",
                ""],
            ["",
                "",
                ""
            ]);
        $dn.makeButtonLogin(Usuario.Nombre.toUpperCase(), $f.logout);
    };
    const Profesor = function () {
        $dn.clear();
        $dn.makeButton("Inicio", HomeImg);
        $dn.makeButton("perfil", $f.perfil);
        $dn.makeDropdownButton("funciones",
            ["Mis cursos",
                "Controlar",
                ""],
            ["",
                "",
                ""
            ]);
        $dn.makeButtonLogin(Usuario.Nombre.toUpperCase(), $f.logout);
    };

    //METHODS
    
    this.Init = function (Rol) {
        switch (Rol) {
            case undefined: Anonimous(); break;
            case "ADMINISTRADOR": Administrador(); break;
            case "DIRECTOR DE ESTUDIOS": DirEstudios(); break;
            case "PROFESOR": Profesor(); break;
            case "PRECEPTOR": Preceptor(); break;
            case "ALUMNO": Alumno(); break;
            case "INSCRIPTO": Alumno(); break;
            case "EXCLUIDO": Anonimous(); break;
        };
    };
};
const $n = new $$Nav();
