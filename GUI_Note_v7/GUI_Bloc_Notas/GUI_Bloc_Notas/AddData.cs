using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Create By: wsullivan
/// Version 1.5v
/// Date: 2016-07-25
/// </summary>
namespace GUI_Bloc_Notas
{
    class AddData
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
                SqlCommand notas = new SqlCommand("INSERT INTO textos VALUES(@texto)", conecta);                
                notas.Parameters.Add("@texto", text);
                notas.ExecuteNonQuery();                
                conecta.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Conexion\t\n\n"+ex,"Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
