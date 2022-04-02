using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class Supplier
    {
        [Column("SupplierId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        public int? CityId { get; set; }
        [JsonIgnore]
        public City City { get; set; }
        //nav props 
        [JsonIgnore]
        public List<AnimalOrder> AnimalOrders { get; set; }
        [JsonIgnore]
        public List<MerchandiseOrder> MerchandiseOrders { get; set; }
        public Supplier()
        {
            AnimalOrders = new List<AnimalOrder>();
            MerchandiseOrders = new List<MerchandiseOrder>();
        }



    }
}
