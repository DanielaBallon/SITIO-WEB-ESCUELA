

namespace BASICA
{
   
        /// <summary>
        /// implementa la dispersion de una clave
        /// </summary>
        public interface IHashing
        {
            /// <summary>
            /// dispersa  data en un string 
            /// </summary>
            /// <param name="Data">palabra a dispersar</param>
            /// <returns>dato dispersado</returns>
            string Hash(string Data);
        }
    
}
