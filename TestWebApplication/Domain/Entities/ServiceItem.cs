using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Domain.Entities
{
    public class ServiceItem : Entity
    {
        [Required(ErrorMessage = "Отсутствует заголовок")]
        [Display(Name = "Название")]
        public virtual string Title { get; set; } = string.Empty;

        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; } = string.Empty;
    }
}
