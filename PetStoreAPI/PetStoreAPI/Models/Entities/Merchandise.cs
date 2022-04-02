using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class Merchandise
    {
        [Column("ItemId")]
        public int Id { get; set; }
        public string Description { get; set; }
        public int QuantityOnHand { get; set; }
        [DataType(DataType.Currency)]
        public Decimal ListPrice { get; set; }
        [Column("Category")]
        public string CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }

        //Navigation props
        [JsonIgnore]
        public List<SaleItem> SaleItems { get; set; }
        [JsonIgnore]
        public List<OrderItem> OrderItems { get; set; }

        public Merchandise()
        {
            SaleItems = new List<SaleItem>();
            OrderItems = new List<OrderItem>();
        }
    }
}
