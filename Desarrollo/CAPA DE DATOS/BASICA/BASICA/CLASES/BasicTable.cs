using System.Data;
namespace BASICA
{
    public abstract class BasicTable : IABMFTable
    {
        #region abstract methods
        public abstract string PathSchema { get; }
        public abstract string Path { get; }
        public abstract void Modify();
        public abstract void Add();
        public abstract void Create();
        public abstract string Find();
        public abstract string List();
        public abstract void Erase();
        #endregion
        #region methods
        public int ID { get; set; }
        public IIMage IIM { get => new Image(); }
        public DataTable Load()
        {
            DataTable Dt = new DataTable();
            Dt.ReadXmlSchema(PathSchema);
            Dt.ReadXml(Path);
            return Dt;
        }
        public void Save(DataTable Dt)
        {
            Dt.WriteXmlSchema(PathSchema);//escribe en el archivo AlumnosSchema.xml
            Dt.WriteXml(Path);//escribe en el archivo Alumnos.xml
        }
        #endregion
    }
}

