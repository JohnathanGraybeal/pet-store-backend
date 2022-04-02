using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class Employee
    {
        [Column("EmployeeId"),Required]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateHired { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateReleased { get; set; }
        public int EmployeeLevel { get; set; }
        public string Title { get; set; }
        public string TaxPayerId { get; set; }
        public int ManagerId { get; set; }

        //nav props 
        [JsonIgnore]
        public List<AnimalOrder> AnimalOrders { get; set; }
        public int? CityId { get; set; }
        [JsonIgnore]
        public City City { get; set; }
        [JsonIgnore]
        public List<Sale> Sales { get; set; }
        [JsonIgnore]
        public List<MerchandiseOrder> MerchandiseOrders { get; set; }

        public Employee()
        {
            AnimalOrders = new List<AnimalOrder>();
            Sales = new List<Sale>();
            MerchandiseOrders = new List<MerchandiseOrder>();
        }

    }
}
