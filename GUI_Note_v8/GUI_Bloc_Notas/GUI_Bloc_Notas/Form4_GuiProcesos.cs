using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
/// <summary>
/// Create By: wsullivan
/// Version 1.5v
/// Date: 2016-07-25
/// </summary>
namespace GUI_Bloc_Notas
{
    public partial class Form4_GuiProcesos : Form
    {
        /// <summary>
        /// Metodo contructor de la clase que inicia el proceso
        /// </summary>
        public Form4_GuiProcesos()
        {
            InitializeComponent();
            actualizarSistema();
            timer1.Enabled = true;
        }
        /// <summary>
        /// Metodo de actualizacion de procesos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actualizarEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actualizarSistema();
        }
        /// <summary>
        /// Metodo de iniciacion de lista de procesos
        /// </summary>
        public void actualizarSistema() {
            //Limpiando las listas
            listBox_ProcesosEjecucion.Items.Clear();
            listBox_MemoriaFisica.Items.Clear();
            listBox_MemoriaVirtual.Items.Clear();

            int count = 1;
            //recorrido del los procesos
            foreach (Process proceso in Process.GetProcesses())
            {
                double memoryFisical = ((proceso.VirtualMemorySize64 / 1048576)*0.01);
                double VMvirtual = ((proceso.VirtualMemorySize64 / 1048576)*0.01);               

                listBox_ProcesosEjecucion.Items.Add(count + "- " + proceso.ProcessName); //Nombre del proceso
                listBox_MemoriaFisica.Items.Add(count + "- " + memoryFisical);    //RAM
                listBox_MemoriaVirtual.Items.Add(count + "- " + VMvirtual/*proceso.VirtualMemorySize64*/); //Memory Virtual

                count = count + 1;  //Conteo de los indices de procesos
            }
            toolStripStatusLabel2.Text = listBox_ProcesosEjecucion.Items.Count.ToString(); //cantidad de procesos
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void finalizarProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminarProceso();
        }
        /// <summary>
        /// Metodod de eliminacion del procesos seleccionado
        /// </summary>
        public void eliminarProceso() {
            try
            {
                foreach (Process proceso in Process.GetProcesses())
                {
                    //seleccion de proceso
                    string objeto = listBox_ProcesosEjecucion.SelectedItem.ToString();
                    string[] objeto2 = objeto.Split('-'); //operacion sobre los contenidos

                    if (proceso.ProcessName == objeto2[1])
                    {  //Sentecnia de comparacion                        
                        string opcion = Convert.ToString(MessageBox.Show("¿SEGURO QUE DESEA DETENER EL PROCESO?", "ALERTA DEL SISTEMA", MessageBoxButtons.YesNo,MessageBoxIcon.Warning));
                        if (opcion.Equals("Yes"))
                        {
                            proceso.Kill(); //Eliminacion del proceso selesccionado
                        }
                        else
                        {
                            //Accion vacia
                            break;
                        }
                    }
                }
            }
            catch (Exception i) //Exception por errores
            {
                MessageBox.Show("Proceso no seleccionado\n" + i, "Error del Sistema", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Metodo de formulario de informacion sobre el software
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3_About objeto = new Form3_About();
            objeto.Show();
        }
        /// <summary>
        /// Metodo vacio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form4_GuiProcesos_Load(object sender, EventArgs e)
        {
            //Vacio
        }
        /// <summary>
        /// Metodo de volver al menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2_Menu objeto = new Form2_Menu();
            objeto.Show();
            this.Dispose();
        }
        /// <summary>
        /// Timer de actualizacion de los procesos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            actualizarSistema();
        }
    }
}
