using System.Net;
using System.Net.Mail;
using UstaelTicaretArtvin.Entities;

namespace UstaelTicaretArtvin.WebUI.Utils
{
    public class MailHelper
    {
        public static async Task SendMailAsync(Contact contact)
        { 
            SmtpClient smtpClient= new SmtpClient("" , 587);
            smtpClient.Credentials = new NetworkCredential("", "");
            smtpClient.EnableSsl = true;
            MailMessage message= new MailMessage();
            message.From= new MailAddress("");
            message.To.Add("ustaelticaret@hotmail.com");
            message.Subject = "Siteden Mesaj Geldi";
            message.Body= $" <h1> Mail Bilgileri </h1> İsim: {contact.Name} {contact.Surname} <hr/> Email: {contact.Email}<hr/> Telefon : {contact.Phone} <hr/> Mesaj: {contact.Message} <hr/> Mesaj Tarihi: {DateTime.Now} ";

            message.IsBodyHtml= true;
            await smtpClient.SendMailAsync(message);    
            smtpClient.Dispose();
        }

    }
}
