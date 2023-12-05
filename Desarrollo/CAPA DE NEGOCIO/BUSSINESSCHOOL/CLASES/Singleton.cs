using BASICA;

namespace BUSSINESSCHOOL 
{
    internal partial class Singleton: ParentSingleton
    {
        static Singleton instance => new Singleton(); // static : se carga una sola vez cuando se invoca por primera vez a la clase 
        private Singleton() { }                 //Private: permite que no se pueda crear otro constructor publico
        public static Singleton GetInstance => instance;  // se puede acceder de aca, que va devolver la instancia
    }
}

/*Intenal: visible dentro del mismo ensablado
Partial: la clase singleton puede estar dividida en varios archivos
Singleron herada de la clase ParentSingleton de la capa de datos que centraliza la creación y el acceso a instancias de diferentes interfaces
es decir que la clase singleton maneja a travez de una sola instancia (todo los objetos del sistema) 
desventajas: sobrecarga cuando hay muchos usuarios
ventajas: uno solo es el que maneja todos los datos


*/
