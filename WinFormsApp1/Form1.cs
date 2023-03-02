using Macoratti.EnviaEmail;
using System;
using System.Collections;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
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

        private void button3_Click_1(object sender, EventArgs e) // método cancelar novo
        {

            Application.Exit();
        }
        private void button3_Click(object sender, EventArgs e) // método cancelar antigo
        {

        }

        private void button2_Click_1(object sender, EventArgs e) // método incluir novo
        {        
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] arr = openFileDialog1.FileNames;
                    aAnexosEmail = new ArrayList();
                    textBox9.Text = string.Empty;
                    aAnexosEmail.AddRange(arr);
                    foreach (string s in aAnexosEmail)
                    {
                        textBox9.Text += s + ";";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e) // método incluir antigo
        {

        }

        private void button1_Click_1(object sender, EventArgs e) // método enviar
        {
            if (String.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Endereço de email do destinatatio invalido", "Erro");
                return;
            }
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Endereço de email do remetente invalido!", "Erro");
                return;
            }
            if (String.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Definição do assunto invalida", "erro");
                return;
            }

            if (String.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Mensagem inválida", "Erro");
                return;
            }

            //separa os anexos em um array de string
            string[] arr = textBox9.Text.Split(';'); // nessa linha eu uso o nome do campo anexo

            //cria um novo array list
            aAnexosEmail = new ArrayList();

            //percorre o array de  string e inclui os anexos
            for (int i = 0; i < arr.Length; i++)
            {
                if (!String.IsNullOrEmpty(arr[i].ToString().Trim()))//REMOVE ESPAÇOS EM BRANCO QUE PODEM SER INCLUIDOS NO CAMPO
                {
                    aAnexosEmail.Add(arr[i].ToString().Trim());
                }
            }
            // se existirem anexos, envia a mensagem com
            // a chamada a enviaMensagemComAnexos senão
            // usa o método enviaMensagemEmail

            if (aAnexosEmail.Count > 0)
            {
                
                string resultado = EnviarEmail.EnviaMensagemComAnexos(textBox6.Text, textBox2.Text, textBox7.Text,textBox8.Text, aAnexosEmail);
                MessageBox.Show(resultado, "email e anexos enviados com sucesso!");
            }
            else
            {
                string resultado = EnviarEmail.EnviarMensagemEmail(textBox6.Text, textBox2.Text, textBox7.Text, textBox8.Text);
                MessageBox.Show(resultado, "email enviado com sucesso");

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

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        } 

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

    }
}
