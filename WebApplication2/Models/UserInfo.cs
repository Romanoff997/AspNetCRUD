using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class UserInfo
    {
        [Required]
        public string Id { get; set; }

        [Display(Name = "Energy")]
        public string Energy { get; set; }

        [Display(Name = "Gold")]
        public string Gold { get; set; }

        [Display(Name = "Rubies")]
        public string Rubies { get; set; }
    }
}
