using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppAspnetcore.ViewModels
{
    public class ContactViewModels
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Observacao { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "O valor só pode ter 250 caractere")]
        public string Message { get; set; }
    }
}
