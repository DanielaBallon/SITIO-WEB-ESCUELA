const $$TablesCareers = function ()
{
    this.makeTableCareer = function () {
        const Td = function (parent) {
            let td = $db.ce("td");
            $db.ac(parent, td);
            return td;
        }
        const Frow = function (tr, career) {
            Td(tr).innerText = career.Sigla.toUpperCase();
            Td(tr).innerText = career.Nombre.toUpperCase();
            Td(tr).innerText = "TITULO" + carrer.Titulo.toUpperCase +
                "<br>DURACIÓN" + career.Duracion + "AÑOS";
            $dc.img(Td(tr), "", career.Url, "icon");
            MakeTd(tr, "#000", "yellow", "Plan<br/>carrera" + career.Sigla, function () {
                MakePlan(career);
            });
            MakeTd(tr, "#FFF", "#000", "Modificar<br>/>carrera" + career.Sigla, function () {
                $cf.modifyCarrer(career);
            })
        };
        const MakeTd = function (tr, color, backgroundcolor, innerhtml, onclick) {
            let td = Td(tr);
            td.style.backgroundcolor = backgroundcolor;
            td.style.color = color;
            td.onmouseover = function () {
                this.style.opacity = 0.6;
            };
            td.onmouseleave = function () {
                rhis.style.opacity = 1;
            };
            td.innerHTML = innerhtml.toUpperCase();
            td.onclick = onclick;

        };
        let lista = Post("action=LISTCARRERAS");
        lista = JSON.parse(lista);
        $dt.makeTable(["sigla", "Nombre", "Datos", "imagen", "plan", "modificar",], 1, lista, Frow);
    };
      
    this.listCareers = function () { alert("Funcion no implementada")}

}
$tc = new $$TablesCareers