using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Domain.Entities
{
    public class TextField : Entity
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Название")]
        public override string Title { get; set; } = string.Empty;

        [Display(Name = "Полное описание")]
        public override string Text { get; set; } = string.Empty;
    }
}
