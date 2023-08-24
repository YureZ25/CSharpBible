using System.ComponentModel.DataAnnotations;

namespace SessionsAndCookies.ViewModels
{
    public class PersonVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [Range(0, 100)]
        public int Age { get; set; }
    }
}
