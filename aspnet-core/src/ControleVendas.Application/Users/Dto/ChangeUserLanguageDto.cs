using System.ComponentModel.DataAnnotations;

namespace ControleVendas.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}