using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Create By: wsullivan
/// Version 1.5v
/// Date: 2016-07-25
/// </summary>
namespace GUI_Bloc_Notas
{
    class DataBaseInjection
    {   
        /// <summary>
        /// Objeto de clase coneccion
        /// </summary>
        Conneccion conexion = new Conneccion();
        /// <summary>
        /// Metodo para establecer concexcion y insertar notas en la tabla
        /// </summary>
        /// <param name="text"></param>
        public void addNote(string text)
        {
            try
            {
                SqlConnection conecta = conexion.coneccion();
                conecta.Open();                             
                SqlCommand notas = new SqlCommand("INSERT INTO blocs VALUES(@texto)", conecta);                
                notas.Parameters.Add("@texto", text);
                notas.ExecuteNonQuery();                
                conecta.Close();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error de Conexión\n", ex);
            }
            //exportaData();
        }
    }
}
