
//VARIABLES GLOBALES
let Rol;
const Home = function () { Section.innerHTML = ""; };
const HomeImg = function () {
    Home();
    let img = $dc.img(Section, "IMAGENES/PortadaPE.jpg").className = "portada";

};
const Post = function (data) {
    //funciona con browsers da ultimageneracion
    const request = new XMLHttpRequest();
    var resp = null;
    request.onreadystatechange = function () {
        if (request.readyState === 4 && request.status === 200) {
            resp = request.responseText;
        }
    };
    request.open("POST", "default.aspx", false);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.send(data);
    return resp;
};//envia un post al servidoe (pag aspx.cs)
const AnularF5 = function () { };
const OnLoad = function () {
    HomeImg();
    $n.Init(Rol);

};
//EVENTO INICIAL
window.onload = OnLoad;
