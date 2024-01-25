//CLASES
const $$DomBasic = function () {
    //parametros
    //funciones
    //métodos
    this.id = function (id) { return document.getElementById(id); };
    this.ce = function (type) { return document.createElement(type); };
    this.ac = function (parent, child) { parent.appendChild(child); };
    this.rc = function (parent, child) { parent.removeChild(child); };
};
const $$DomControls = function () {
    //Funciones
    const ce = function (type) { return document.createElement(type); };
    const ac = function (parent, child) { parent.appendChild(child); };
    const rc = function (parent, child) { parent.removeChild(child); };
    const AddControl = function (parent, strelem) {
        let control = ce(strelem);
        ac(parent, control);
        return control;
    };
    const AddInput = function (parent, type) {
        let input = AddControl(parent, "input");
        input.type = type;
        input.required = true;
        return input;
    };
    // Metodos
    this.AddInput = function (parent, type) {
        return AddInput(parent, type);
    };
    this.AddControl = function (parent, strelement) {
        return AddControl(parent, strelement);
    };
    this.form = function (title, texinput) {
        let f = AddControl(Section, "form");
        let header = $dc.div(f);
        header.className = "header";
        $dc.label(header, title);
        let img = $dc.img(header, "IMAGENES/eliminar.png");
        img.onclick = HomeImg;
        let cform = $dc.div(f);
        cform.id = "Cform";
        let foot = $dc.div(f);
        foot.id = "Foot";
        let submit = AddInput(foot, "submit");
        submit.value = texinput.toUpperCase();
        submit.id = "Submit";
        let reset = AddInput(foot, "reset");
        reset.value = "CANCELAR";
        reset.id = "Reset";
        return f;
    };
    this.formImg = function (title, textinput, Fload) {
        //FUNCTIONS
        // Obtener el contenido del iframe despues de que se haya cargado 
        const Load = function () {
            let res = this.contentWindow.document.childNodes[0].innerText;
           
            if (res === "") return;
            Fload(res); // procesamiento adicional que dependerá del propósito del formulario
        };


        //DESARROLLO
        let f = $dc.form(title, textinput);
        f.method = "POST";  //los datos del formulario se enviarán al servidor utilizando el método HTTP POST.
        f.action = "default.aspx"; //los datos del formulario se enviarán al archivo "default.aspx" en el servidor para su procesamiento.
        f.enctype = "multipart/form-data";
        let ifr = $d.ce("iframe"); //elemento HTML que se utiliza para incrustar contenido externo
        ifr.name = "iframe";
        ifr.style.display = "none"; //oculto
        $d.ac(Section, ifr); 
        f.target = "iframe"; // target: especifica el nombre o contexto de navegacion donde se abrirá el resultado del envío del formulario después de hacer clic en el botón "submit".
                            //Esto significa que cuando se envíe el formulario, la respuesta del servidor se cargará en el iframe oculto en lugar de cargar toda la página
        ifr.onload = Load; // la funcion Load 
        //se ejecutará una vez que la página o el recurso solicitado en el atributo action del formulario se haya cargado en el iframe.
        return f;
    };
    this.div = function (parent) {
        return AddControl(parent, "div");
    };
    this.label = function (parent, innertext) {
        let lbl = AddControl(parent, "label");
        lbl.innerText = innertext.toUpperCase();
        return lbl;
    };
    this.img = function (parent, src) {
        let imagen = AddControl(parent, "img");
        imagen.src = src;
        return imagen;
    };
    this.inputHidden = function (name, value) {
        let h = AddInput(Cform, "hidden");
        h.name = name;
        h.value = value;
        return h;
    };
    this.inputText = function (textlabel) {
        $dc.label(Cform, textlabel);
        let itext = AddInput(Cform, "text");
        return itext;
    };
    this.inputTextDisabled = function (textlabel) {
        let inp = $dc.inputText(textlabel);
        inp.disabled = true;
        return inp;
    };
    this.inputNumber = function (textlabel) {
        $dc.label(Cform, textlabel);
        let itext = AddInput(Cform, "number");
        return itext;
    };
    this.inputMail = function (textlabel) {
        $dc.label(Cform, textlabel);
        let itext = AddInput(Cform, "email");
        return itext;
    };
    this.inputDate = function (textlabel) {
        $dc.label(Cform, textlabel);
        let idate = AddInput(Cform, "date");
        return idate;
    };
    this.select = function (textlabel) {
        $dc.label(Cform, textlabel);
        let sel = AddControl(Cform, "select");
        return sel;
    };
    this.option = function (parent, innertext, value) {
        let opt = AddControl(parent, "option");
        opt.innerText = innertext;
        opt.value = value;
        return opt;
    };
    this.inputPassword = function (textlabel) {
        $dc.label(Cform, textlabel);
        let pass = AddInput(Cform, "password");
        return pass;
    };
    this.inputsPasswordConfirm = function () {
        let pass = $dc.inputPassword("contraseña");
        pass.placeholder = "Si no modifica contraseña no ingrese";
        let confirm = $dc.inputPassword("conf. contraseña");
        confirm.style.display = "none";
        confirm.required = false;
        pass.required = false;
        pass.onchange = function () {
            if (pass.value === "") {
                confirm.style.display = "none";
                confirm.value = "";
                confirm.required = false;
                confirm.setCustomValidity("");
                return;
            }
            confirm.style.display = "block";
            confirm.required = true;
        };
        confirm.onchange = function () {
            if (pass.value === confirm.value) confirm.setCustomValidity("");
            else confirm.setCustomValidity("NO COINCIDEN LAS CONTRASEÑAS");
        };
        return pass;
    };
    this.inputFile = function (textlabel, name) {
        $dc.label(Cform, textlabel);
        let file = AddInput(Cform, "file");
        file.name = name;
        file.required = false;
        return file;
    };
    this.inputFileImg = function (textlabel, name) {
        const Change = function () {
            if (this.files.length === 0) return;
            if (this.files[0].type.match('image.*')) { this.setCustomValidity(""); }
            else { this.setCustomValidity("No es un archivo de imagen".toUpperCase()); }
        };
        let fileimg = $dc.inputFile(textlabel, name);
        fileimg.onchange = Change;
        fileimg.required = false;
        return fileimg;
    };
    this.inputFilePdf = function (textlabel, name) {
        const Change = function () {
            if (this.files.length === 0) return;
            let filename = this.files[0].name;
            let datos = filename.split(".");
            let extensión = datos[datos.length - 1];
            if (extensión === "pdf") { this.setCustomValidity(""); }
            else { this.setCustomValidity("No es un archivo pdf".toUpperCase()); }
        };
        let filepdf = $dc.inputFile(textlabel, name);
        filepdf.onchange = Change;
        filepdf.required = false;
        return filepdf;
    };
    this.forgot = function (parent) {
        let forg = $dc.div(parent);
        forg.className = "forgot";
        forg.innerText = "OLVIDE MI CONTRASEÑA";
        return forg;
    };
    this.doubleButton = function () {
        let d1 = AddControl(Cform, "div");
        let d2 = AddControl(Cform, "div");
        d1.className = "dblbutton1";
        d2.className = "dblbutton2";
        return [d1, d2];
    };
    this.li = function (parent) {
        return AddControl(parent, "li");
    };
    this.a = function (parent, innertext) {
        let a = AddControl(parent, "a");
        a.innerText = innertext.toUpperCase();
        return a;
    };
};
const $$DomNav = function () {
    this.clear = function () {
        ul.innerHTML = "";
        var linksToRemove = document.querySelectorAll('.LOGIN');
        linksToRemove.forEach(function (link) {
            link.remove();
        });
    };

    this.makeButton = function (innertext, eventclick) {
        let li = $dc.li(ul);
        let a = $dc.a(li, innertext.toUpperCase());
        a.onclick = eventclick;
        return li;
    };
 /*   this.makeButtonLogin = function (text, eventclick) {
        let li = $dc.li(ul);
        li.className = "LOGIN";
        let a = $dc.a(li, text.toUpperCase());
        a.id = "Login";
        a.onclick = eventclick;
    };*/


    this.makeButtonLogin = function (text, eventclick) {
        let a = $dc.a(Nav, text.toUpperCase())
        a.className = "LOGIN";
        a.id = "Login";
        a.onclick = eventclick;
    }
    this.makeDropdownButton = function (text, arraytext, arrayeventsclik) {
        let li = $dc.li(ul);
        li.className = "dropdown";
        let a = $dc.a(li, text); // Asigna el enlace a la variable 'a'
        a.className = "dropdownbtn"; // Asigna la clase 'dropdownbtn' al enlace
        let div = $dc.div(li);
        div.className = "dropdown-content"; // Asigna la clase 'dropdown-content' al div
        for (var i = 0; i < arraytext.length; i++) {
            $dc.a(div, arraytext[i]).onclick = arrayeventsclik[i];
        }
    };
};

const $$DomTable = function () {
    //PARAMETROS
    let table, Header,
        List, Rows, Frow,
        Pos, MaxPos, Footer,
        BtStart, BtPrevious, BtEnd;
    //FUNCIONES
    const Tr = function () {
        return $dc.AddControl(Table, "tr");
    };
    const Th = function (tr) {
        return $dc.AddControl(tr, "th");

    };
    const Td = function (tr) {
        return $dc.AddControl(tr, "td");
    };
    const MakeWheel = function () {
        Table.onmousewheel = function (e) {
            if (e.wheelDelta > 0) {

                if (--Pos < 1) Pos = 0;
                MakeTable();
            } else {
                Pos++;
                if (Pos > MaxPos) Pos = MaxPos;
                MakeTable();
            }

        };
    };
    const MakeClick = function () {
        BtStart.onclick = function () { Pos = 0; MakeTable(); };
        BtPrevious.onclick = function () {
            Pos -= Rows;
            if (Pos < 0) Pos = 0;
            MakeTable();
        };
        BtNext.onclick = function () {
            Pos += Rows;
            if (Pos > MaxPos) Pos = MaxPos;
            MakeTable();
        };
        BtEnd.onclick = function () {
            Pos = MaxPos;
            MakeTable();

        };
        MakeWheel();//utliliza el mousewheel
    };
    const MakeVisibility = function () {
        BtStart.style.display = "none";
        BtPrevious.style.display = "none";
        BtNext.style.display = "none";
        BtEnd.style.display = "none";
        //visibilidad en funcion de pos
        if (Pos > 0) {
            BtStart.style.display = "block";
            BtPrevious.style.display = "block";
        }
        if (Pos < MaxPos) {
            BtNext.style.display = "block";
            BtEnd.style.display = "block";
        }
        MakeClick();//eventos on click de los botones
    };
    const MakeFooter = function () {
        let tr = Tr();
        Footer = Th(tr);
        Footer.id = "Footer";
        Footer.colSpan = Header.length;
        BtStart = $dc.div(Footer);
        BtPrevious = $dc.div(Footer);

        BtEnd = $dc.div(Footer);
        BtNext = $dc.div(Footer);
        BtStart.innerText = "<<";
        BtPrevious.innerText = "<";
        BtNext.innerText = ">";
        BtEnd.innerText = ">>";
        BtStart.className = "btfoot left";
        BtPrevious.className = "btfoot left";

        BtEnd.className = "btfoot right";
        BtNext.className = "btfoot right";
        MakeVisibility();
    };
    const MakeBody = function () {
        for (var i = Pos; i < Pos + Rows && i < List.length; i++) {
            let tr = Tr();
            for (var j = 0; j < Header.length; j++) {
                Td(tr);
            }
            Frow(tr, List[i]);
        }
        MakeFooter();
    };
    const MakeHeader = function () {
        let tr = Tr();
        for (var i = 0; i < Header.length; i++) {
            Th(tr).innerText = Header[i].toUpperCase();
        }
        MakeBody();
    };
    const MakeTable = function () {
        table = $d.id("Table");
        if (table === null || table === undefined) {
            table = $d.ce("table");
            $d.ac(Section, table);
            table.id = "Table";
        }
        table.innerHTML = "";
        MakeHeader();
    };
    //METODOS
    this.Table = function (header, list, rows, frow) {
        Header = header;
        List = list;
        Rows = rows;
        Frow = frow;
        Pos = 0;
        MaxPos = List.length - Rows;
        MakeTable();
    };
    this.TdControl = function (td, innerhtml, background, colortext, onclick) {
        td.innerHTML = innerhtml.toUpperCase();
        td.style.backgroundColor = background;
        td.style.color = colortext;
        td.onclick = onclick;
        td.onmouseover = function () { this.style.opacity = "0.6"; };
        td.onmouseleave = function () { this.style.opacity = "1"; };
    };
};
const $$DomPatterns = function () {
    this.MakeSelect = function (textselect, list, flist, valorinicial) {
        let s = $dc.select(textselect);
        s.innerHTML = "";
        for (var i = 0; i < list.length; i++) {
            let o = flist(list[i]);
            $dc.option(s, o.text.toUpperCase(), o.value);
        }
        if (valorinicial !== undefined) s.value = valorinicial;

        return s;
    };
    const Exists = function (value, lis, flis) {
        for (var i = 0; i < lis.length; i++) {
            let o = flis(lis[i]);
            if (value === o.value) return true;
        }
        return false;
    };

    this.MakeSelectPosibles = function (textselect, list, flist, listposibles, flistposibles, valorinicial) {
        let s = $dc.select(textselect);
        s.innerHTML = "";
        for (var i = 0; i < listposibles.length; i++) {
            let o = flistposibles(listposibles[i]);
            if (!Exists(o.value, list, flist))
                $dc.option(s, o.text.toUpperCase(), o.value);
        }
        if (valorinicial !== undefined) s.value = valorinicial;
        return s;
    };
    this.UpdateSelect = function (select, list, flist, valorinicial) {
        let s = select;
        s.innerHTML = "";
        for (var i = 0; i < list.length; i++) {
            let o = flist(list[i]);
            $dc.option(s, o.text.toUpperCase(), o.value);
        }
        if (valorinicial !== undefined) s.value = valorinicial;
    };
    this.UpdateSelectPosibles = function (select, list, flist, listposibles, flistposibles, valorinicial) {
        let s = select;
        s.innerHTML = "";
        for (var i = 0; i < listposibles.length; i++) {
            let o = flistposibles(listposibles[i]);
            if (!Exists(o.value, list, flist))
                $dc.option(s, o.text.toUpperCase(), o.value);
        }
        if (valorinicial !== undefined) s.value = valorinicial;

    };
    this.existeUnDato = function (list, flist, dato) {
        for (var i = 0; i < list.length; i++) {
            if (flist(list[i]).value === dato) return true;
        }
        return false;

    };

};
//INSTANCIAS
const $d = new $$DomBasic(),
    $dn = new $$DomNav(),
    $dc = new $$DomControls(),
    $dt = new $$DomTable(),
    $dp = new $$DomPatterns();