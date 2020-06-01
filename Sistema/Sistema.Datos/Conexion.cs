using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sistema.Datos
{
    public class Conexion
    {

        private string Base;// Para almacenar el nombre de la base de datos 
        private string Servidor;//para indicar donde esta alojada la base de datos 
        private string Usuario;//usuario para acceder a la BD
        private string Clave;//clave del usuario  para acceder a la BD
        private bool Seguridad;//
        private static Conexion Con = null;// objeto para instanciar la clase conexion 


        private Conexion()// constructor de la clase  para enviar valores a las propiedades de la clase 
        {
            this.Base = "dbsistema";
            this.Servidor = "LENOVO-PC";
            this.Usuario = "sa";
            this.Clave = "adrianespinal8297204399";
            this.Seguridad = true;// Para utilizar la seguridad de windows 
        }
        public SqlConnection CrearConexion()//
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor + "; Database=" + this.Base + ";";    
                if (this.Seguridad)
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security = SSPI";
                }
                else
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "User Id=" + this.Usuario + ";Password=" + this.Clave;
                }
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion getInstancia()// Para Verificar si se tiene una instancia de esta clase 
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }

    }

}
