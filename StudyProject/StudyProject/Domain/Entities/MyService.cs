using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyProject.Domain.Entities
{
    public class MyService : DbEntity
    {
        [Required(ErrorMessage = "Заполнить название услуги")]
        [Display(Name = "Название услуги")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание услуги")]
        public override string Subtitle { get; set; }

        [Display(Name = "Текст услуги")]
        public override string MyText { get; set; }
    }
}
