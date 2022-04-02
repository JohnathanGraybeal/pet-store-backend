using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class AnimalOrderItem
    {
        [Column("OrderId")]
        public int AnimalOrderId { get; set; }
        [Required]
        public int AnimalId { get; set; }
        [DataType(DataType.Currency)]
        public Decimal Cost { get; set; }

        //Nav props
        [JsonIgnore]
        public AnimalOrder AnimalOrder { get; set; }
        [JsonIgnore]
        public Animal Animal { get; set; }

       
    }
}
