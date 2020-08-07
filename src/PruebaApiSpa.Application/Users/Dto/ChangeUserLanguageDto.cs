using System.ComponentModel.DataAnnotations;

namespace PruebaApiSpa.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}