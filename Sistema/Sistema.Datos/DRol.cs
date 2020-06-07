using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Sistema.Datos
{
    public class DRol
    {
        public DataTable Listar()
        {

            SqlDataReader Resultado;// Para leer las secuencias de las filas de la BD
            DataTable Tabla = new DataTable();// La tabla en memoria de la BD
            SqlConnection SqlCon = new SqlConnection();//Variable para establecer la conexion con la BD
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();// Para crear la instancia de la  conexion 
                SqlCommand Comando = new SqlCommand("rol_listar", SqlCon);//sqlcomand representa una instruccion transac sql o el procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;// Se le espesifica que es de tipo procedimiento almacenado
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);// Para rellenar el datatable con el metodo load
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
