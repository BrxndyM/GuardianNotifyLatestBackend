using System.ComponentModel.DataAnnotations;

namespace GuardianNotifyBackend.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}