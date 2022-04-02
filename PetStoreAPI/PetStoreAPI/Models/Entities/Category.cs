using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class Category
    {
        [Column("Category"),Key, MaxLength(50)]
        public string AnimalCategory { get; set; }
        public string Registration { get; set; }

        //Navigation prop
       
       // public List<Animal> Animals { get; set; }
        [JsonIgnore]
        public List<Breed> Breeds { get; set; }
        public Category()
        {
           // Animals = new List<Animal>();
            Breeds = new List<Breed>();
        }
    }
}
