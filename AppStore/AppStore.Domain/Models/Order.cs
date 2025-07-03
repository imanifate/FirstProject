using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Domain.Models
{
    public class Order:BaseEntity
    {
        public int UserId { get; set; }
        public bool IsFinaly { get; set; }

        [ForeignKey("UserId")]
        public Account? Accounts { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

    }
    public class OrderDetail:BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }


        [ForeignKey("OrderId")]
        public Order? Orders { get; set; }
        [ForeignKey("ProductId")]
        public AppStore.Domain.Models.Product? Product { get; set; }

    }
}
