using GYM_PW.Views.ContactView;

namespace GYM_PW.Interfaces
{
    public interface IEmailService
    {
        Task EnviarCorreoContacto(ContactModel contacto);
    }
}
