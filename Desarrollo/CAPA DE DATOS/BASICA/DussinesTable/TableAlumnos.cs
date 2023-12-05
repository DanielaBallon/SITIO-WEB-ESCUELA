using BASICA;
using System.Data;
using System;
using System.Web;
namespace BussinesTable
{
    public class TableAlumnos : BasicTable,ITable
    {
        public TableAlumnos()
        {
            Prefix = "Alumno";
            if (!System.IO.File.Exists(PathSchema)) Create();
        }
        public HttpPostedFile Fu { get; set; }
        public override string PathSchema => AppDomain.CurrentDomain.BaseDirectory+"AlumnosSchema.xml";
        public override string Path => AppDomain.CurrentDomain.BaseDirectory+"Alumnos.xml";
        public string Nombre { get; set; }
        public int Dni { get ; set; }
        public string Mail { get; set; }
        public string Directory => "Alumnos";
        public string BaseDirectory => "Imagenes";
        public string Prefix { get; set; }


        public override void Create()
        {
            DataTable Dt = new DataTable();
            Dt.TableName = "Alumnos";
            DataColumn Dc = Dt.Columns.Add("ID", typeof(int));
            Dc.AutoIncrement = true;
            Dc.AutoIncrementSeed = 1;
            Dc.AutoIncrementStep = 1;
            Dt.PrimaryKey = new DataColumn[] { Dt.Columns["ID"] };
            Dt.Columns.Add("Nombre", typeof(string));
            Dt.Columns.Add("Dni", typeof(int)).Unique = true;
            Dt.Columns.Add("Mail", typeof(string)).Unique = true;
            Save(Dt);
        }


        public override void Erase()
        {
            DataTable Dt = Load();
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (Dt.Rows[i]["ID"].ToString() == ID.ToString())
                {
                    Dt.Rows[i].Delete();
                    Save(Dt);
                    IIM.Erase(ID + ";" + BaseDirectory + ";" + Directory + ";" + Prefix);
                }
            }
        }




        public override void Add()
        {
            if (Dni == 0 || Nombre == "" || Mail == "") {
                throw new Exception("Datos incompletos");
            }
            DataTable Dt = Load();
            DataRow Dr = Dt.NewRow();
            Dr["Nombre"] = Nombre;
            Dr["Dni"] = Dni;
            Dr["Mail"] = Mail;
            Dt.Rows.Add(Dr);
            Save(Dt);
            IIM.Add(Fu, Dr["ID"] + ";" + BaseDirectory + ";" + Directory + ";" + Prefix);
        }
  
        public override void Modify()
        {
            if (ID==0||Dni == 0 || Nombre == "" || Mail == "")
            {
                throw new Exception("Datos incompletos");
            }
            DataTable Dt = Load();
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if(ID.ToString()==
                    Dt.Rows[i]["ID"].ToString())
                {
                    Dt.Rows[i].BeginEdit();
                    Dt.Rows[i]["Nombre"] = Nombre;
                    Dt.Rows[i]["Dni"] = Dni;
                    Dt.Rows[i]["Mail"] = Mail;
                    Dt.Rows[i].EndEdit();
                    Save(Dt);
                    IIM.Add(Fu, Dt.Rows[i]["ID"] + ";" + BaseDirectory + ";" + Directory + ";" + Prefix);
                    return;
                }

            }
        }
        public override string Find()
        {
            if (ID == 0) { throw new Exception("Id incorrecto"); }
            DataTable Dt = Load();
            foreach(DataRow Dr in Dt.Rows)
            {
                if (Dr["ID"].ToString() == ID.ToString())
                {
                    return DrImg(Dr);
                }
            }
            throw new Exception("NO SE ENCONTRÓ NINGÚN ALUMNO");
        }
        public override string  List()
        {
            DataTable Dt = Load();
            if (Dt.Rows.Count == 0) { return "[]"; }
            string Json = "[";
            foreach(DataRow Dr in Dt.Rows)
            {
                Json += DrImg(Dr) + ","; 
            }
            return Json.Remove(Json.Length - 1) + "]"; 
        }
        string DrImg(DataRow Dr)
        {
            string url = IIM.URL(Dr["ID"] + ";" + 
                BaseDirectory + ";" +
                Directory + ";" + Prefix);
            IJson Json = new Json();
            string json = Json.json(Dr);
            json = Json.addObject(json, "Url", url);
            return json;
        }

    }
}
