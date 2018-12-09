using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Model.DataModel;

namespace WebProje.Models.Contact
{
    public class ContactViewModel
    {
        public List<Settings> SettingsList { get; set; }

        public int ID { get; set; }

        [Required(ErrorMessage = "You have to enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You have to enter your email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You have to enter a subject.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "You have to enter a message.")]
        public string Message { get; set; }
    }
}