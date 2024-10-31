using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LogisticCompany.Models
{
    public class Recepient
    {
        public int Id { get; set; }
        [DisplayName("ФИО")]
        [MaxLength(30)]
        [Required]
        public string FIO { get; set; }
        [DisplayName("Год рождения")]
        [Required]
        public int BirthYear { get; set; }
        [DisplayName("Почтовый индекс")]
        [Required]
        public int PostalCode { get; set; }
        [DisplayName("Адрес доставки")]
        [MaxLength(50)]
        [Required]
        public string DeliveryAddress { get; set; }
        [DisplayName("Телефон")]
        [MaxLength(15)]
        [Required]
        public string Phone { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
