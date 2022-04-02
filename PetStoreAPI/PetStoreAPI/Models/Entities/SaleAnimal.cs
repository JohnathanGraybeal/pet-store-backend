using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class SaleAnimal
    {
        
        public int SaleId { get; set; }
        [JsonIgnore]
        public Sale Sale { get; set; }
       
        public int AnimalId { get; set; }
        [JsonIgnore]
        public Animal Animal { get; set; }
        [DataType(DataType.Currency)]
        public Decimal SalePrice { get; set; }

       
    }
}
