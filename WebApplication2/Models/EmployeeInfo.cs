using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class EmployeeInfo
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Gender { get; set; }
        [Required]

        public string Company { get; set; }
        [Required]

        public string Department { get; set; }
    }
}
