
namespace BASICA
{
    public class ParentSingleton
    {
        public IHashing IHashing
        {
            get =>new Sha();
        }
        public IIMage IIMage
        {
            get =>new Image();
            
        }
        public IConnection IConnection=> Connection.GetInstance; 
        
        public IJson IJson
        {
            get => new Json();
            
        }
        public IListToTable IListToTable
        {
            get => new ListToTable();
            
            
        }
    }
}
//centraliza la creación y el acceso a instancias de diferentes interfaces