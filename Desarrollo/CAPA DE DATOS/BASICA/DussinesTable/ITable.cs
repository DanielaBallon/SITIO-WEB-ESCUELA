using System.Web;
namespace BussinesTable
{
    public  interface ITable
    {
        string Nombre { get; set; }
        int Dni { get; set; }
        string Mail { get; set; }
        string Directory { get; }
        string BaseDirectory { get; }
        string Prefix { get; set; }
        HttpPostedFile Fu { get; set; }
    }
}