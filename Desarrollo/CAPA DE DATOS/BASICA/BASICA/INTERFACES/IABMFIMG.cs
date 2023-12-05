
namespace BASICA { 
  
    public interface IABMFIMG : IABMF
    {
        string DirBase { get; }
        string Directory { get; }
        string Prefix { get; }
        string MakeData { get; }
        System.Web.HttpPostedFile Fu { get; set; }
    }
}

