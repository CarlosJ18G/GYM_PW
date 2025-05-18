using GYM_PW.Interfaces;
using GYM_PW.Views.ContactView;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace GYM_PW.InterfazServices
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration configuration)
        {
            _config= configuration;
        }
        
        public async Task EnviarCorreoContacto(ContactModel contacto)
        {
            var emailEmisor = _config.GetValue<string>("Email:Correo");
            var clave = _config.GetValue<string>("Email:Clave");
            var host = _config.GetValue<string>("Email:Host");
            var puerto = _config.GetValue<int>("Email:Puerto");

            var smtpCliente = new SmtpClient(host, puerto);
            smtpCliente.EnableSsl = true;
            smtpCliente.UseDefaultCredentials = false;

            smtpCliente.Credentials = new NetworkCredential(emailEmisor, clave);

            var mensaje = new MailMessage(emailEmisor, emailEmisor, $"{contacto.Nombre} ({contacto.Email}) quiere contactarte", contacto.Mensaje);

            await smtpCliente.SendMailAsync(mensaje);
        }
        
    }
}
