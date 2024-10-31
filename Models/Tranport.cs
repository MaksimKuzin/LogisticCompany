using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LogisticCompany.Models
{
    public class Tranport
    {
        public int Id { get; set; }
        [DisplayName("Транспортный номер")]
        [MaxLength(30)]
        [Required]
        public string TransportNumber { get; set; }
        [DisplayName("Марка")]
        [MaxLength(30)]
        [Required]
        public string Brand { get; set; }
        [DisplayName("Модель")]
        [MaxLength(30)]
        [Required]
        public string Model { get; set; }
        [DisplayName("Дата регистрации")]
        [Required]
        public DateOnly RegistrationDate { get; set; }
        [DisplayName("Цвет")]
        [MaxLength(30)]
        [Required]
        public string Color { get; set; }
        [DisplayName("Грузоподъемность")]
        [Required]
        public int Capacity { get; set; }
        public virtual List<Order> Orders { get; set; }

    }
}
