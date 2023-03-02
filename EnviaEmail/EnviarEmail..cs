using System;
using System.IO;
using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Web;
using System.Reflection;

namespace Macoratti.EnviaEmail
{
    
    public class EnviarEmail
    { 
       // public EnviarEmail()
       // {

       // }
    
    /// <summary>
    /// Transmite uma mensagem de email sem anexos
    /// </summary>
    /// <param name="Destinatario">Destinatario (Recipient)</param>
    /// <param name="Remetente">Remetente(Sender)</param>
    /// <param name="Assunto">Assunto da mensagem(subjact)</param>
    /// <param name="enviaMensagem">Corpo de mensagem(Body)</param>"
    /// <return>Status de mensagem</return>

    public static string EnviarMensagemEmail(string Destinatario, string Remetente, string Assunto, string enviaMensagem)
    {
        try
        {
            // valida o email
            bool bValidaEmail = ValidaEnderecoEmail(Destinatario);

            // Se o email não é valido retorna uma mensagem
            if (bValidaEmail == false)
                return "Email do destiantário inválido:" + Destinatario;

            // cria uma mensagem
            MailMessage mensagemEmail = new MailMessage(Remetente, Destinatario, Assunto,enviaMensagem );
                // ---------------------------------
                //obtem os valores smtp do arquivo de configuração. 

                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                var configuration = builder.Build();

                string host = configuration.GetValue<string>("Smtp:Host");
                string password = configuration.GetValue<string>("Smtp:Password");
                string username = configuration.GetValue<string>("Smtp:Username");
                int port = configuration.GetValue<int>("Smtp:Port");


                /*
                Configuration configurationFile = WebConfigurationManager.OpenWebConfiguration(null);
                MailSettingsSectionGroup mailSettings = configurationFile.GetSectionGroup("System.net/mailSettings") as MailSettingsSectionGroup;
                if (mailSettings !=null)
                {
                    string host = mailSettongs.Smtp.Network.Host;
                    string password = mailSettings.Smtp.Network.Password;
                    string username = mailSettings.Smtp.Network.UserName;
                    int port = mailSettings.Smtp.Port;
                }*/


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);// CONFIRMAR 
            client.EnableSsl = true;
            NetworkCredential cred = new NetworkCredential("developerteste4@gmail.com", "fuyfrwupiuawkplj");
            client.Credentials = cred;

            //inclui as credenciais
            client.UseDefaultCredentials = false; //estava true vc alterou para false

            //envia a mensagem
            client.Send(mensagemEmail);

            return "Mensagem enviada para" + Destinatario + "as" + DateTime.Now.ToString() + ".";
        }
        catch (Exception ex)
        {
           // string erro = ex.InnerException.ToString();
            return ex.Message.ToString();
        }
    }

    public static string EnviaMensagemComAnexos(string Destinatario, string Remetente,string Assunto, string enviaMensagem, ArrayList anexos)
    {
        try
        {
            // valida o email
            bool bValidaEmail = ValidaEnderecoEmail(Destinatario);

            if (bValidaEmail == false)
                return "Email do destinatario inválido:" + Destinatario;

            //Cria uma mensagem
            MailMessage mensagemEmail = new MailMessage(Remetente, Destinatario, Assunto, enviaMensagem);
            //obtem os anexos contidos em um arquivo arraylist e inclui na mensagem
            foreach(string anexo in anexos)
            {
                Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                mensagemEmail.Attachments.Add(anexado);
            }

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            NetworkCredential cred = new NetworkCredential("developerteste4@gmail.com", "fuyfrwupiuawkplj");
            client.Credentials = cred; 

            //inclui as credenciais
            client.UseDefaultCredentials = false;//estava true vc alterou para false

            // envia a mensagem
            client.Send(mensagemEmail);

            return "Mensagem enviada para" + Destinatario + "as" + DateTime.Now.ToString() + ".";
        }
            catch (Exception ex)
            {
                string erro = ex.InnerException != null ? ex.InnerException.ToString() : "";
                return ex.Message.ToString() + erro;
            }

        }
    ///<summary>
    ///Confirma a validade de um email
    ///</summary>
    ///<param name="enderecoEmail">Email a ser validado</param>
    ///<returns>Retorna True se o email for valido</returns>
    
    public static bool ValidaEnderecoEmail(string enderecoEmail)
    {
        try
        {
            //define a expressão regular para validar o email
            string texto_Validar = enderecoEmail;   
            Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
            
            // testa o email com a expressão
            if(expressaoRegex.IsMatch(texto_Validar))
            {
                // o email é valido
                return true;
            }
            else
            {
                // o email é inválido
                return false;
            }
        }
        catch(Exception)
        {
            throw;
        }
    }

    }
}