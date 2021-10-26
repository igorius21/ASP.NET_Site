using System.ComponentModel.DataAnnotations;

namespace StudyProject.Models
{
    public class LoginView
    {
        [Required]
        [Display(Name = "Логин")]
        public string AdminName { get; set; }

        [Required]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string AdminPassword { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool AdminRemember { get; set; }
    }
}
