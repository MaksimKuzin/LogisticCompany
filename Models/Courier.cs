using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LogisticCompany.Models
{
    public class Courier
    {
        public int Id { get; set; }
        [DisplayName("FIO")]
        [MaxLength(30)]
        [Required]
        public string FIO { get; set; }
        [DisplayName("Серия и номер паспорта")]
        [Required]
        public long Passport { get; set; }
        [DisplayName("Дата рождения")]
        [Required]
        public DateOnly BirthDate { get; set; }
        [DisplayName("Дата начала приема на работу")]
        [Required]
        public DateOnly EmploymentDate { get; set; }
        [DisplayName("Начало рабочего дня")]
        [Required]
        public TimeOnly StartWorkTime { get; set; }
        [DisplayName("Конец рабочего дня")]
        [Required]
        public TimeOnly EndWorkTime { get; set; }
        [DisplayName("Место проживания")]
        [MaxLength(30)]
        [Required]
        public string LivingPlace { get;set; }
        [DisplayName("Телефон")]
        [MaxLength(15)]
        [Required]
        public string Phone { get; set; }
        public virtual List<Order> Orders { get; set; }

    }
}
