using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado2020
{
    public partial class Form1 : Form
    {
        String palabraOculta = "";
        int numFallos = 0;
        bool finPartida = false;

        List<Button> listaBotones = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            primeraPalabra();
            bReiniciar.Visible = false;
        }

        private void primeraPalabra()
        {
            palabraOculta = seleccionaPalabra();
            String guiones = "";
            for (int i = 0; i < palabraOculta.Length; i++)
            {
                guiones += "_ ";
            }
            label1.Text = guiones;
        }

        private void letraPulsada(object sender, EventArgs e)
        {
            if (!finPartida)
            {
                Button b = (Button)sender;
                b.Enabled = false;
                String caracter = b.Text;
                caracter = caracter.ToUpper();
                chequeaCaracter(caracter);
                listaBotones.Add(b);
            }


        }

        private void chequeaCaracter(String caracter)
        {
            if (palabraOculta.Contains(caracter))
            {


                for (int i = 0; i < palabraOculta.Length; i++)
                {
                    if (palabraOculta[i] == caracter[0])
                    {
                        label1.Text = label1.Text.Substring(0, 2 * i)
                                + caracter
                                + label1.Text.Substring(2 * i + 1);
                    }
                }

                if (!label1.Text.Contains('_'))
                {
                    numFallos = -500;
                    finPartida = true;
                    bReiniciar.Visible = true;


                }

            }
            else
            {
                numFallos++;
                if (numFallos >= 6)
                {
                    finPartida = true;
                    bReiniciar.Visible = true;
                    label1.Text = "";
                    for (int i = 0; i < palabraOculta.Length; i++)
                        {
                            label1.Text += palabraOculta[i] + " ";
                        }
                    }


                }


                switch (numFallos)
            {
                case 0: pictureBox1.Image = Properties.Resources.ahorcado_0; break;
                case 1: pictureBox1.Image = Properties.Resources.ahorcado_1; break;
                case 2: pictureBox1.Image = Properties.Resources.ahorcado_2; break;
                case 3: pictureBox1.Image = Properties.Resources.ahorcado_3; break;
                case 4: pictureBox1.Image = Properties.Resources.ahorcado_4; break;
                case 5: pictureBox1.Image = Properties.Resources.ahorcado_5; break;
                case -500: pictureBox1.Image = Properties.Resources.ahorcado_win; break;
                default: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
            }
        }


        private String seleccionaPalabra()
        {
            String[] listaPalabras = { "MANDALORIAN", "CARA", "GREEF", "MOFF", "KUIIL", "BABYYODA", "TROOPER", "DRPERSHING", "MAYFELD", "CLIENT"   };

            Random aleatorio = new Random();

            int posicion = aleatorio.Next(listaPalabras.Length);

            return listaPalabras[posicion].ToUpper();
        }

        private void botonReinicio(object sender, EventArgs e)
        {

            primeraPalabra();
            finPartida = false;
            numFallos = 0;
            pictureBox1.Image = Properties.Resources.ahorcado_0;


            foreach (Button item in listaBotones)
            {
                item.Enabled = true;
            }

            listaBotones.Clear();
            bReiniciar.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
