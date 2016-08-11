using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Bloc_Notas
{
    public partial class Form2_Menu : Form
    {
        public Form2_Menu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Metodo vacio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Vacio
        }
        /// <summary>
        /// Metodo que llama al formulario de Procesos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form4_GuiProcesos objeto = new Form4_GuiProcesos();
            objeto.Show();
            this.Hide();
        }
        /// <summary>
        /// Metodo que llama al formulario de Notas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Form1_GUINote objeto = new Form1_GUINote();
            objeto.Show();
            this.Hide();
        }
    }
}
