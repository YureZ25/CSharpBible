using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Forms.ViewModels
{
    public class LoginVM : IValidatableObject // Приреализации этого интерфейса можно делать кастомную
                                              // валидацию (Но лучше вообще использовать либы типо FluentValidation xD)
    {
        [Required] // Задаем валидацию через аттрибуты
        [EmailAddress]
        [MaxLength(30, ErrorMessage = "Слишком много букав!")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Без пароля - никак...")]
        public string Password { get; set; } = null!;

        // Метод для кастомной валидации, эти ошибки появятся в ModelState
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Email.EndsWith(".ru"))
            {
                yield return new ValidationResult("Россиянам тут (везде) не рады", new[] { nameof(Email) });
            }

            if (!Regex.IsMatch(Password, ".*\\d"))
            {
                yield return new ValidationResult("Пароль должен содержать цифры - иди смени его", new[] { nameof(Password) });
            }
        }
    }
}
