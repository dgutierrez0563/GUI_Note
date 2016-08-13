using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
    public partial class Form1_GUINote : Form
    {
        Conneccion conectar = new Conneccion();
        /// <summary>
        /// variable que comprueba el save
        /// </summary>
        public bool saved;
        /// <summary>
        /// Objeto de dataBaseinjection
        /// </summary>
        DataBaseInjection objeto = new DataBaseInjection();
        /// <summary>
        /// Metodo constructor inicializador
        /// </summary>
        public Form1_GUINote()
        {
            InitializeComponent();
            saved = false;
        }
        /// <summary>
        /// Metoto vacio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //empty
        }
        /// <summary>
        /// Metodo que abre el archivo guardado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //objeto.openFile();
            string read;
            openFileDialog1.ShowDialog();
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
                read = file.ReadLine();
                richText_Note.Text = read.ToString();
            }
            catch (Exception ex) {
                MessageBox.Show("Error de selección de fichero\t\n"+ex,"Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }       
        }
        /// <summary>
        /// Metodo que cierra el sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sliendo del Sistema","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Application.Exit();
        }
        /// <summary>
        /// Metodo que llama a insertarNotes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertaNotas();
        }
        /// <summary>
        /// Metodo para almacenar notas con DataBaseIjection en base de datos
        /// </summary>
        public void insertaNotas() {
            saved = true;
            //if (!richText_Note.Equals("")) {

            //}
            //enviamos al metodo addNote el parametro txt
            objeto.addNote(richText_Note.Text);
            //saved = false;
            MessageBox.Show("Datos almacenados con exito!","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //Conneccion conectar = new Conneccion();
            //SqlConnection conecta = conectar.coneccion();
            //conecta.Open();
            //SqlCommand exportTitle = new SqlCommand("SELECT TOP(1)titulo FROM bloc ORDER BY idBloc DESC", conecta);
            //exportTitle.ExecuteNonQuery();            
            //string titulo = Convert.ToString(exportTitle);
            //saveFileDialog1.FileName = titulo;
            //string directory = "C:\\Users\\wsullivan\\Desktop\\S.O I Notes";
            //var ruta = saveFileDialog1
            //SqlCommand texto = new SqlCommand("SELECT TOP(1)texto FROM blocs ORDER BY idBloc DESC", conecta);
            //string textoPlano = Convert.ToString(texto);
            //saveFileDialog1.FileName = "empty.txt";
            //var ruta = saveFileDialog1.ShowDialog();
            //if (ruta == DialogResult.OK)
            //{
            //    using (var SaveFile = new System.IO.StreamWriter(saveFileDialog1.FileName))
            //    {
            //        SaveFile.WriteLine(textoPlano);
            //    }
            //    //text.ExecuteNonQuery();         
            //}
            //else {
            //    MessageBox.Show("No se guardaron los datos","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);

            //}
            ////exportTitle.ExecuteNonQuery();
            //texto.ExecuteNonQuery();
            //conecta.Close();
        }
        /// <summary>
        /// Metodo que realiza el procedimiento de exporte de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //SqlConnection nodo=conectar.coneccion();
            SqlConnection conecta = conectar.coneccion();
            conecta.Open();
            string consulta = "SELECT TOP(1) *FROM blocs ORDER BY idBloc DESC";
            SqlCommand texto = new SqlCommand(consulta,conecta);
            
            richText_Note.Text = texto.ToString();
            saveFileDialog1.FileName = "empty.txt";
            var ruta = saveFileDialog1.ShowDialog();
            if (ruta == DialogResult.OK)
            {
                using (var SaveFile = new System.IO.StreamWriter(saveFileDialog1.FileName))
                {
                    SaveFile.WriteLine(richText_Note.Text);
                }      
            }
            else
            {
                MessageBox.Show("No se exportaron los datos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            texto.ExecuteNonQuery();
            conecta.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!richText_Note.Equals(""))
            {
                if (!saved == true)
                {
                    string mensaje = Convert.ToString(MessageBox.Show("¿Desea gusrdar los cambios?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (mensaje.Equals("Yes"))
                    {
                        insertaNotas();
                        richText_Note.Clear();
                    }
                    else
                    {
                        richText_Note.Clear();
                    }
                }
                else
                {
                    richText_Note.Clear();
                }
                saved = false;
            }
        }
        /// <summary>
        /// Metodo que muestra el formularios About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3_About objeto = new Form3_About();
            objeto.Show();
        }
        /// <summary>
        /// Lllamada o
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openNote_exe();
        }
        ///// <summary>
        ///// Metodo openExplporer.exe
        ///// </summary>
        //public void openExplorer_exe() {
        //    ProcessStartInfo info = new ProcessStartInfo();
        //    info.FileName = "explorer.exe";
        //    info.WorkingDirectory = "C:\\Windows\\System32";
        //    Process.Start(info);
        //}
        /// <summary>
        /// Metodo openNote.exe
        /// </summary>
        public void openNote_exe() {
            ProcessStartInfo info = new ProcessStartInfo();
            info.UseShellExecute = true;
            info.FileName = "notepad.exe";
            info.WorkingDirectory = "C:\\Windows\\System32";
            Process.Start(info);
        }
    }
}
