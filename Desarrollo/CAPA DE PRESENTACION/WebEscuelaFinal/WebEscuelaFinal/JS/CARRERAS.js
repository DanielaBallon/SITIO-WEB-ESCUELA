const $$Carreras = function () {

    
 
    this.ABMCarreras = function() {
        const ListCarreras = function () {
            const res = Post("accion=LISTCARRERAS");
            //if (res.length === 0) return;
            const List = JSON.parse(res);
            const H = [
                "Sigla",
                "Nombre",
                "Descripcion",
                "Imagen",
                "Plan de estudio",
                "Modificar",
                "Eliminar",
            ];
            const Frow = function (tr, carrera) {
                tr.childNodes[0].innerText = carrera.Sigla.toUpperCase();
                tr.childNodes[1].innerText = carrera.Nombre.toUpperCase();
                tr.childNodes[2].innerHTML =
                    "TITULO: " +
                    carrera.Titulo.toUpperCase() +
                    "<br>DURACIÓN: " +
                    carrera.Duracion +
                    " AÑOS";
                $dc.img(tr.childNodes[3], carrera.URL).style.height = "3rem";
                let pdfLink = $d.ce("a");
                pdfLink.href = carrera.URLPDF; // Asigna la URL del PDF al enlace
                pdfLink.target = "_blank"; // Abre el enlace en una nueva pestaña
                pdfLink.innerText = "Ver Plan";
                tr.childNodes[4].innerHTML = ""; // Limpia el contenido actual de la celda
                tr.childNodes[4].appendChild(pdfLink); // Agrega el enlace al PDF en la celda
                $dt.TdControl(
                    tr.childNodes[5],
                    "modificar",
                    "#333",
                    "#fff",
                    function () {
                        const Res = Post("accion=OBTERNERCARRERA&Sigla=" + carrera.Sigla)
                        const Car = JSON.parse(Res);
                        $c.modifyCarrera(Car);
                    }
                );


                $dt.TdControl(
                    tr.childNodes[6],
                    "eliminar",
                    "#933",
                    "#fff",
                    function () {
                        let res = Post("accion=DELETECARRERA&ID=" + carrera.ID);
                        if (res !== "OK") {
                            alert(res);

                            return;
                        }
                        $c.ABMCarreras();
                    }
                );
                
            };

            $dt.Table(H, List, 4, Frow);
        };
        Fload = function (res) {
            if (res !== "ok") { alert(res); return; }              
           
            $c.ABMCarreras();
        };
       

        Home();
        let f = $dc.formImg("AGREGAR CARRERA" , "Agregar", Fload);
        f.className = "w60 l18";

        let nombre = $dc.inputText("nombre");
        nombre.name = "Nombre";

        let sigla = $dc.inputText("sigla");
        sigla.name = "Sigla";

        let duracion = $dc.inputNumber("duracion");
        duracion.name = "Duracion";

        let titulo = $dc.inputText("titulo");
        titulo.name = "Titulo";

        $dc.inputFileImg("Foto", "Foto");
        $dc.inputFilePdf("Plan", "Plan");

        let estado = $dc.select("select", "estado");
        estado.name = "Estado";
        $dc.option(estado, "Activo", "Activo");
        $dc.option(estado, "Inactivo", "Inactivo");
        $dc.inputHidden("accion", "ADDCARRERA");
        ListCarreras();

 

    }


    this.modifyCarrera = function (Car) {
        const Fload = function (res) {
            if (res !== "OK") {
                alert(res);
                return;
            }

            $c.ABMCarreras();
        };

        Home();
        let f = $dc.formImg("MODIFICAR CARRERA" + Car.Sigla, "Modificar", Fload);
        f.className = "w60 l18";

        let nombre = $dc.inputText("nombre");
        nombre.name = "Nombre";
        nombre.value = Car.Nombre;

        let sigla = $dc.inputText("sigla");
        sigla.name = "Sigla";
        sigla.value = Car.Sigla;
        let duracion = $dc.inputNumber("duracion");
        duracion.name = "Duracion";
        duracion.value = Car.Duracion;

        let titulo = $dc.inputText("titulo");
        titulo.name = "Titulo";
        titulo.value = Car.Titulo;

        $dc.inputFileImg("Foto", "Foto");
        $dc.inputFilePdf("Plan", "Plan");

        let estado = $dc.select("select", "estado");
        estado.name = "Estado";
        estado.value = Car.Estado;
        $dc.option(estado, "Activo", "Activo");
        $dc.option(estado, "Inactivo", "Inactivo");
        $dc.inputHidden("ID", Car.ID);
        $dc.inputHidden("accion", "MODIFYCARRERA");

        
    };

    
    this.ListCarreras = function () {
        Home();
        const res = Post("accion=LISTCARRERAS");
            //if (res.length === 0) return;
            const List = JSON.parse(res);
            const H = [
                "Sigla",
                "Nombre",
                "Descripcion",
                "Imagen",
                "Plan de estudio",
                     ];
            const Frow = function (tr, carrera) {
                tr.childNodes[0].innerText = carrera.Sigla.toUpperCase();
                tr.childNodes[1].innerText = carrera.Nombre.toUpperCase();
                tr.childNodes[2].innerHTML =
                    "TITULO: " +
                    carrera.Titulo.toUpperCase() +
                    "<br>DURACIÓN: " +
                    carrera.Duracion +
                    " AÑOS";
                $dc.img(tr.childNodes[3], carrera.URL).style.height = "3rem";
                let pdfLink = $d.ce("a");
                pdfLink.href = carrera.URLPDF; // Asigna la URL del PDF al enlace
                pdfLink.target = "_blank"; // Abre el enlace en una nueva pestaña
                pdfLink.innerText = "Ver Plan";
                tr.childNodes[4].innerHTML = ""; // Limpia el contenido actual de la celda
                tr.childNodes[4].appendChild(pdfLink); // Agrega el enlace al PDF en la celda

            };

            $dt.Table(H, List, 4, Frow);
        };


    
}
let $c = new $$Carreras();
