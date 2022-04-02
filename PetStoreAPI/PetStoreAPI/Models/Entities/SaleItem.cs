using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class SaleItem
    {
       
       
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        //Navigation property 
        [JsonIgnore]
        public Sale Sale { get; set; }
        [Required]
        public int SaleId { get; set; }
        [JsonIgnore]
        public Merchandise Merchandise { get; set; }
        [Column("ItemId"),Required]
        public int MerchandiseId { get; set; }


    }
}
