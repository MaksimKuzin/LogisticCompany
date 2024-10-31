using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace LogisticCompany.Models
{
    public class Order
    {
        public int Id { get; set; }
        [DisplayName("Отправитель")]
        [MaxLength(50)]
        [Required]
        public string Sender { get; set; }
        [DisplayName("Дата заказа")]
        [Required]
        public DateTime OrderDate { get; set; }
        [DisplayName("Дата доставки")]
        [Required]
        public DateTime DeliveryDate { get; set; }
        [DisplayName("Цена")]
        [Precision(15, 2)]
        [Required]
        public decimal Price { get; set; }
        public int CourierId { get; set; }
        public int RecepientId { get; set; }
        public int TransportId { get; set; }
        public virtual Courier Courier { get; set; }
        public virtual Recepient Recepient { get; set; }
        public virtual Tranport Tranport { get; set; }
        public virtual List<Warehouse> Warehouses { get; set; }


    }
}
