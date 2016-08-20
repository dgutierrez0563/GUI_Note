using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Bloc_Notas
{
    class Conneccion
    {
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Conneccion() {/* constructr vacio*/ }
        /// <summary>
        /// Metodo que establece la concexcion con la database notes
        /// </summary>
        /// <returns></returns>
        public SqlConnection coneccion()
        {
            SqlConnection conecta = new SqlConnection("Data Source=WSULLIVANPC\\SQLEXPRESS;Initial Catalog=notes;Integrated Security=true");
            return conecta;
        }
    }
}
