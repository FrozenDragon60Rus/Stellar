using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Domain.Entities
{
    public class ServiceItem : Entity
    {
        [Required(ErrorMessage = "Отсутствует заголовок")]
        [Display(Name = "Название")]
        public override string Title { get; set; } = string.Empty;

        [Display(Name = "Краткое описание")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание")]
        public override string Text { get; set; } = string.Empty;
    }
}
