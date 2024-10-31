using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LogisticCompany.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        [DisplayName("Название")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [DisplayName("Адрес")]
        [MaxLength(50)]
        [Required]
        public string Address { get; set; }
        [DisplayName("Телефон")]
        [MaxLength(15)]
        [Required]
        public string Phone { get; set; }
        [DisplayName("Вместимость")]
        [Required]
        public int Capacity { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
