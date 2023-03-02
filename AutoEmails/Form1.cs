using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoEmails
{
    public partial class Form1 : Form
    {
         /// <summary>
         /// um array lista contendo todos os anexos
         /// </summary>
    
        ArrayList aAnexosEmail;

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) //enviar
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Endereço de email do destinatatio invalido", "Erro");
                return;
            }
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Endereço de email do remetente invalido!", "Erro");
                return;
            }
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Definição do assuto invalida", "erro");
                return;
            }

            if (String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Mensagem inválida","Erro");
                return;
            }

            //separa os anexos em um array de string
            string[] arr = textBox5.Text.Split(';');

            //cria um novo array list
            aAnexosEmail = new ArrayList();

            //percorre o array de  string e inclui os anexos
            for(int i = 0; i < arr.Length; i++)
            {
                if (!String.IsNullOrEmpty(arr[i].ToString().Trim()))
                {
                    aAnexosEmail.Add(arr[i].ToString().Trim());
                  }
                }
            // se existirem anexos, envia a mensagem com
            // a chamada a enviaMensagemComAnexos senão
            // usa o método enviaMensagemEmail


            if(aAnexosEmail.Count > 0)
            {
                string resultado = EnviarEmail.
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
