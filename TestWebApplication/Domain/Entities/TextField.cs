using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Domain.Entities
{
    public class TextField : Entities
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Название")]
        public virtual string Title { get; set; } = string.Empty;

        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; } = string.Empty;
    }
}
