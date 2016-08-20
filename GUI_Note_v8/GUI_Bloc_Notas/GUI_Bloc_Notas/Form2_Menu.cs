using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Bloc_Notas
{
    public partial class Form2_Menu : Form
    {
        /// <summary>
        /// Consstructor de la clase
        /// </summary>
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
        /// <summary>
        /// Void
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Menu_Load(object sender, EventArgs e)
        {
            //Vacio
        }
        /// <summary>
        /// Open Explorer.exe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ExplorerExe_Click(object sender, EventArgs e)
        {
            openExplorer_exe();
        }

        /// <summary>
        /// Metodo openExplporer.exe
        /// </summary>
        public void openExplorer_exe()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer.exe";
            info.WorkingDirectory = "C:\\Windows\\System32";
            Process.Start(info);
        }
        /// <summary>
        /// Metodo openNote.exe
        /// </summary>
        public void openNote_exe()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.UseShellExecute = true;
            info.FileName = "notepad.exe";
            info.WorkingDirectory = "C:\\Windows\\System32";
            Process.Start(info);
        }
        /// <summary>
        /// Open Help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Help_Click(object sender, EventArgs e)
        {
            Form3_About formHelp = new Form3_About();
            formHelp.Show();
        }
        /// <summary>
        /// Salir del sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Sliendo del Sistema", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
    }
}
