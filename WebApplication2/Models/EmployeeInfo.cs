using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class EmployeeInfo
    {
        [Required]
        public Guid ID { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [Display(Name = "Компания")]
        public string Company { get; set; }

        [Display(Name = "Отдел")]
        public string Department { get; set; }
    }
}
