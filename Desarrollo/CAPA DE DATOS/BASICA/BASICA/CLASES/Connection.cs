using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
namespace BASICA
{
    /// <summary>
    /// esta clase genera una conexion a una base de datos
    /// y ejecuta procedimientos almacenados
    /// tolera una sóla conexion en un entorno desconectado
    /// abre y cierra la conexion en cada consulta
    /// la cadena de conexion se puede situar por medio de dos opciones
    /// la primera si es un sitio web atraves del Web.Config con el nombre
    /// "My Connection"
    /// la segunda en el caso de no tener el web.Config
    /// se busca en la carpeta bin el achivo "Conexion.txt"
    /// utiliza el patrón sigleton que permite una sóla instancia de ella
    /// AppDomain.CurrentDomain.BaseDirectory devuelve el directorio base de la aplicación en la que se está ejecutando
    /// </summary>
    public class Connection : IBasicConnection, IConnection
    {
        #region Variables
        string PathConfig = AppDomain.CurrentDomain.BaseDirectory + "Web.Config"; //Esta variable almacena la ruta completa al archivo Web.Config
        string PathConnection = AppDomain.CurrentDomain.BaseDirectory + @"..\Conexion.txt"; //almacena la ruta completa al archivo Conexion.txt.
        SqlConnection MyConnection = new SqlConnection();
        SqlCommand MyCommand;
        #endregion
        #region Constructor Singleton
        static Connection instance = new Connection(); // static : se carga una sola vez cuando se invoca por primera vez a la clase
        public static Connection GetInstance => instance; //Public: permite acceder a la intance desde cualquier parte del programa
        private Connection()    //constructor privado de la clase 
        {
            string ConnectionString = "";
            if (File.Exists(PathConfig))
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["My Connection"].ConnectionString;
            }
            else
                if (File.Exists(PathConnection)) ConnectionString = File.ReadAllText(PathConnection);
            else
                throw new Exception("Error No existe archivo de conexión");
            MyConnection.ConnectionString = ConnectionString; // se establece la conexion con el valor del archivo encontrado  
        }
        #endregion  
        #region Iparameters
        //define varios métodos para agregar diferentes tipos de parámetros a un comando SQL. 
        public void AddBit(string name, bool value)
        {
            MyCommand.Parameters.Add("@" + name, SqlDbType.Bit).Value = value;
        }
        public void AddDatetime(string name, DateTime value)
        {
            MyCommand.Parameters.Add("@" + name, SqlDbType.SmallDateTime).Value = value.ToString();
        }
        public void AddFloat(string name, double value)
        {
            MyCommand.Parameters.Add("@" + name, SqlDbType.Float).Value = value;
        }
        public void AddInt(string name, int value)
        {
            MyCommand.Parameters.Add("@" + name, SqlDbType.Int).Value = value;
        }
        public void AddVarchar(string name, int length, string value)
        {
            MyCommand.Parameters.Add("@" + name, SqlDbType.VarChar, length).Value = value;
        }
        #endregion
        #region Iconnection
        public void CreateCommand(string StoreProc, string Data)
        {
            MyCommand = new SqlCommand(StoreProc, MyConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            this.AddData = Data; // Asignación del nombre de la tabla al que se refiere la operación
        }
        public void Delete()
        {
            OpenConnection();
            try { MyCommand.ExecuteNonQuery(); } //Ejecuta Comando Sql y realiza una eliminacion (MyCommand ya contiene una instrucción SQL)
            catch (Exception er)
            { throw new Exception("Error: no se pudo Eliminar " + AddData); }
            finally { MyConnection.Close(); } // cierra la conexion independientemente si hubo exito a error
        }
        public bool Exists()
        {
            OpenConnection();
            try
            { int i = int.Parse(MyCommand.ExecuteScalar().ToString());// Comando de Sql que devuelve un valor escalar 
                return i > 0;
            } // Retorna true si el valor devuelto es mayor que 0 (es decir, existe)
            catch (Exception er)
            { throw new Exception("Error: no se pudo  ver si existe " + AddData); }
            finally { MyConnection.Close(); }
        }
        public DataRow Find()
        {
            OpenConnection();
            try
            {
                DataTable Dt = new DataTable(); // Crea una nueva tabla de datos para almacenar el resultado
                Dt.Load(MyCommand.ExecuteReader()); // Ejecuta el comando SQL y carga los datos en la tabla
                return Dt.Rows[0];// Retorna la primera fila de la tabla(si existe)
                
            }
            catch (Exception er)
            {
                throw new Exception($"Error: no existe {AddData}. Verifique los datos ingresados");

            }
            finally { MyConnection.Close(); }
        }

        public int Insert()
        {
            OpenConnection();
            try
            { int i = int.Parse(MyCommand.ExecuteScalar().ToString());// Ejecuta un comando SQL que devuelve un valor escalar 
                return i;                                               //valor de la primera columna de la primera fila del resultado (ID)
            }// Retorna el valor devuelto por la consulta 
            catch (Exception er)
            { throw new Exception("Error: no se pudo ingresar  " + AddData ); }
            finally { MyConnection.Close(); }
        }
        public DataTable List()
        {
            OpenConnection();
            try
            { DataTable Dt = new DataTable(); Dt.Load(MyCommand.ExecuteReader()); return Dt; }
            catch (Exception er)
            { throw new Exception("Error: no se pudo listar " + AddData ); }
            finally { MyConnection.Close(); }
        }
        public void Update()
        {
            OpenConnection();
            try { MyCommand.ExecuteNonQuery(); } // Ejecuta un comando SQL que realiza una actualización
            catch (Exception er)
            { throw new Exception("Error: no se pudo Modificar " + AddData); }
            finally { MyConnection.Close(); }
        }

        #endregion
        #region IBasicConnection
        public string AddData { get; set; }
        public void OpenConnection() //sqlConection en ADO.NET
        {
            if (MyConnection.State != ConnectionState.Open) //Propiedad que verifica si la coneccion a la base de datos esta abierta
                MyConnection.Open();
        }
        #endregion
    }
}
/*Un SqlCommand contiene tanto el texto de la consulta SQL o el nombre del procedimiento almacenado como los parámetros y
 la conexión a la base de datos en la que se ejecutará. */
/*SqlConnection Permite establecer y administrar la conexión con la base de datos, así como ejecutar comandos SQL y recuperar resultados.
 */

