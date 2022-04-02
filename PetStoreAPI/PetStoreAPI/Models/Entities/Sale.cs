using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class Sale
    {
        [Column("SaleId"),Required]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }
        [DataType(DataType.Currency)]
        public Decimal SalesTax { get; set; }

        //Navigation Props
        [JsonIgnore]
        public List<SaleItem> SaleItems { get; set; }
        public int? EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        public int? CustomerId { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        [JsonIgnore]
        public List<SaleAnimal> SaleAnimals { get; set; }
        public Sale()
        {
            SaleItems = new List<SaleItem>();
            SaleAnimals = new List<SaleAnimal>();
        }
    }
}
