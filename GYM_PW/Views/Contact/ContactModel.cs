using System.ComponentModel.DataAnnotations;

namespace GYM_PW.Views.ContactView
{
    public class ContactModel
    {
        [Required]
        public string Nombre { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Mensaje { get; set; }

    }
}
