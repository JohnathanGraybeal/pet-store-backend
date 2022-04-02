using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class OrderItem
    {
        
        
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public Decimal Cost { get; set; }
        //Navigation props
        [JsonIgnore]
        public MerchandiseOrder MerchandiseOrder { get; set; }
        [Column("PONumber")]
        public int MerchandiseOrderId { get; set; }
        [JsonIgnore]
        public Merchandise Merchandise{ get; set; }
        [Column("ItemId")]
        public int MerchandiseId { get; set; } 
    }
}
