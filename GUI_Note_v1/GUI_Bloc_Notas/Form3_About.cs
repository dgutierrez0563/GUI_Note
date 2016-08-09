using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class Form3_About : Form
    {
        /// <summary>
        /// Metodo inicializador de la clase
        /// </summary>
        public Form3_About()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Metodo de volver al bloc de notas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_VolverMenu_Click(object sender, EventArgs e)
        {            
            this.Dispose();
        }
        /// <summary>
        /// Metodo vacio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form3_About_Load(object sender, EventArgs e)
        {
            //Vacio
        }
    }
}
