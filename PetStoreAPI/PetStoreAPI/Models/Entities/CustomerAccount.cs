using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class CustomerAccount
    {
        [Column("AccountId")]
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        public Decimal Balance { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
