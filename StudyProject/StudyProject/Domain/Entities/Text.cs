using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyProject.Domain.Entities
{
    public class Text : DbEntity
    {
        [Required]
        public string KeyWord { get; set; }

        [Display(Name = "Название текста")]
        public override string Title { get; set; } = "Информационная страница";

        [Display(Name = "Текст содержания")]
        public override string MyText { get; set; } = "Форма записи";
    }
}
