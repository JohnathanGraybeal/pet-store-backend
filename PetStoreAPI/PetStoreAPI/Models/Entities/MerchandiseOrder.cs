using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class MerchandiseOrder
    {
        [Column("PONumber")]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? RecievedDate { get; set; }
        [DataType(DataType.Currency)]
        public Decimal ShippingCost { get; set; }
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        public int SupplierId { get; set; }
        [JsonIgnore]
        public Supplier Supplier { get; set; }
        //Nav props

        [JsonIgnore]
        public List<OrderItem> OrderItems { get; set; }

        public MerchandiseOrder()
        {
            OrderItems = new List<OrderItem>();
        }

    }
}
