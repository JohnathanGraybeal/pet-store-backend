using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class Customer
    {
        [Column("CustomerId")]
        public int Id { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        public int? CityId { get; set; }
        //Nav props
        [JsonIgnore]
        public City City { get; set; }
        [JsonIgnore]
        public CustomerAccount CustomerAccount { get; set; }
        [JsonIgnore]
        public List<Sale> Sales { get; set; }

        public Customer()
        {
            Sales = new List<Sale>();
        }
    }
}
