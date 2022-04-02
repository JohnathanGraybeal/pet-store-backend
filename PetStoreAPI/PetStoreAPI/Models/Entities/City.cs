using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class City
    {
        [Column("CityId")]
        public int Id { get; set; }
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        [Column("City")]
        public string Location { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [DataType(DataType.PostalCode)]
        public string AreaCode { get; set; }
        public int? Population1990 { get; set; }
        public int? Population1980 { get; set; }
        [DefaultValue("USA")]
        public string Country { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        //Nav props
        [JsonIgnore]
        public List<Customer> Customers { get; set; }
        [JsonIgnore]
        public List<Employee> Employees { get; set; }

        public City()
        {
            Customers = new List<Customer>();
            Employees = new List<Employee>();
        }
    }
}
