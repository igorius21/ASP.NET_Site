using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyProject.Domain.Entities
{
    public abstract class DbEntity
    {
        protected DbEntity() => DateAdded = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Название")]
        public virtual string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Текст")]
        public virtual string MyText { get; set; }

        [Display(Name = "Картинка")]
        public virtual string Image { get; set; }

        [Display(Name = "Метатег Title")]
        public string MetaTitle { get; set; }

        [Display(Name = "Метатег Discription")]
        public string MetaDiscription { get; set; }

        [Display(Name = "Метатег Keyword")]
        public string MetaKeyword { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
