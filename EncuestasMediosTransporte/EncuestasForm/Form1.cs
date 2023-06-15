using EncuestasLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncuestasForm
{
    public partial class Form1 : Form
    {

        ProcesoEncuestas proceso = new ProcesoEncuestas();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistroDeEncuestas_Click(object sender, EventArgs e)
        {

            FormRegistroDeEncuesta fRegistro = new FormRegistroDeEncuesta();

           // fRegistro.ShowDialog();

            if (fRegistro.ShowDialog() == DialogResult.OK) {


                Encuesta nuevo = new Encuesta();

                nuevo.UsaBicicleta = fRegistro.cbkUsaBicicleta.Checked;
                nuevo.UsaAuto = true;// Consulta("¿Usa Automóvil?: S/N");
                nuevo.UsaTransportePublico = false;// Consulta("¿Usa Transporte público?: S/N");

                //Console.WriteLine("¿Cuál es la distancia aproximada a su destino de trabajo/estudio en km? (ej:1,5)\n");
                nuevo.DistanciaASuDestino = Convert.ToDouble(Console.ReadLine());

                bool puedeSerContactado = false;//Consulta("¿Puede ser contactado?: S/N");
                if (puedeSerContactado == true)
                {
                    Console.Write("Email: ");
                    nuevo.Email = Console.ReadLine();
                    Console.Write("\n");
                }

                proceso.RegistrarEncuesta(nuevo, puedeSerContactado);
                MessageBox.Show("Encuesta Procesada!");

                /* Console.WriteLine("\nEncuesta procesada!");

                 Console.WriteLine("Presione una tecla para volver al menú principal");
                 Console.ReadKey();¨*/

            }


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           Close();
        }
    }
}
