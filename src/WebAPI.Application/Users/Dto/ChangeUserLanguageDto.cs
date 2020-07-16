using System.ComponentModel.DataAnnotations;

namespace WebAPI.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}