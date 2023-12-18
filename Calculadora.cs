using Calculadora_de_IMC.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_de_IMC
{
    public partial class Calculadora : Form
    {
        double Peso, Altura, IMC;
        string Condicao;
        
        public Calculadora()
        {
            InitializeComponent();
        }


        private void TxtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.SomenteNumero(sender, e);
        }

        private void TxtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.SomenteNumero(sender, e);
        }

        public bool VerificaCampoVazio()
        {
            if (string.IsNullOrWhiteSpace(TxtAltura.Text))
            {
                TxtAltura.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(TxtPeso.Text))
            {
                TxtPeso.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool LimparCampos()
        {
            TxtAltura.Text = string.Empty;
            TxtPeso.Text = string.Empty;
            TxtIMC.Text = string.Empty;
            TxtCondicao.Text = string.Empty;
            Emoji.Visible = false;
            return true;
        }

        private void TxtPeso_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtPeso.Text))
            {
                var peso = Convert.ToDecimal(TxtPeso.Text);

                if (peso % 10 == 9)
                {

                    Math.Round(peso);
                }

                TxtPeso.Text = peso.ToString("N2");
            }
        }

        
        private void TxtAltura_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtAltura.Text))
            {
                var altura = Convert.ToDecimal(TxtAltura.Text);

                if (altura % 10 == 9)
                {
                    Math.Round(altura);
                }

                TxtAltura.Text = altura.ToString("N2");
            }
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            

            if (VerificaCampoVazio() == true)
            {
                Peso = double.Parse(TxtPeso.Text);
                Altura = double.Parse(TxtAltura.Text);
                IMC = Peso / Math.Pow(Altura, 2);

                if (IMC < 18.5)
                {
                    Condicao = "Abaixo do Peso";
                    Emoji.Image = Resources.triste; ;
                    Emoji.Visible = true;


                }
                else if ((IMC >= 18.5) && (IMC < 24.99))
                {
                    Condicao = "Peso Ideal, Parabéns!!!";
                    Emoji.Image = Resources.feliz;
                    Emoji.Visible = true;
                }
                else if ((IMC >= 25) && (IMC < 29.99))
                {
                    Condicao = "Levemente acima do Peso";
                    Emoji.Image = Resources.serio;
                    Emoji.Visible = true;
                }
                else if ((IMC >= 30) && (IMC < 34.9))
                {
                    Condicao = "Obesidade Grau I";
                    Emoji.Image = Resources.triste;
                    Emoji.Visible = true;
                }
                else if ((IMC >= 35) && (IMC < 39.9))
                {
                    Condicao = "Obesidade Grau II(Severa)";
                    Emoji.Image = Resources.triste;
                    Emoji.Visible = true;
                }
                else
                {
                    Condicao = "Obesidade Grau III (Mórbida)";
                    Emoji.Image = Resources.triste;
                    Emoji.Visible = true;
                }


                TxtIMC.Text = IMC.ToString("F");
                TxtCondicao.Text = Condicao.ToString();

            }
            else
            {
                MessageBox.Show("Preencha os campos vazios!!");

            }

        }
        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
    }

