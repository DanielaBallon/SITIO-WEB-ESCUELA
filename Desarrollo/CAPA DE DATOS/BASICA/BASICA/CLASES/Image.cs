using System.IO;
using System.Web;
using System;
namespace BASICA
{
    public class Image : IMakeImg
    { 
        public string DirBase { get; set; }
        public string Directory { get; set; }
        public string Path => AppDomain.CurrentDomain.BaseDirectory+
            DirBase+
            @"\"+Directory+@"\"+
            Prefix+ID+"."+Extension;
        public string Prefix { get; set; }
        public int ID { get; set; }
        public string Extension { get; set; }
        public void ResetPrefix()
        {
            if (Prefix.EndsWith("_")) ChangPrefix();
        }
        public void ChangPrefix()
        {
            if (Prefix.EndsWith("_"))
            {
                Prefix = Prefix.Remove(Prefix.Length - 1);return;
            }
            Prefix += "_";
        }
        public void Add(HttpPostedFile FU, string Data)
        {
            if (FU == null || FU.FileName == "") return;
            Erase(Data);
            FU.SaveAs(Path);
        }
        public void Erase(string Data)
        {
            SplitData(Data);
            ResetPrefix();
            if (File.Exists(Path)){ File.Delete(Path);ChangPrefix(); return; }
            ChangPrefix();
            if (File.Exists(Path)){ File.Delete(Path); ChangPrefix(); return; }
            ResetPrefix();
        }
        public void SplitData(string Data)
        {
            string[] Datos = Data.Split(new char[] { ';' });
            ID = int.Parse(Datos[0]);
            DirBase = Datos[1];
            Directory = Datos[2];
            Prefix = Datos[3];
            Extension = Datos[4];
        }
        public string URL(string Data)
        {
            SplitData(Data);
            ResetPrefix();
            if (File.Exists(Path))
            {
                return DirBase + "/" + Directory + "/" + Prefix + ID + "."+Extension;
            }
            ChangPrefix();
            if (File.Exists(Path))
            {
                return DirBase + "/" + Directory + "/" + Prefix + ID + "."+Extension;
            }
            ResetPrefix();
            return DirBase + "/" + Directory + "/" + Prefix+"default."+Extension;
        }
    }
}