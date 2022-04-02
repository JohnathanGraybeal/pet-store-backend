using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class Breed
    {
        [Column("Category"), MaxLength(50)]
        public string Category { get; set; }
        [Column("Breed"), MaxLength(50)]
        public string AnimalBreed { get; set; }

        //Navigation Prop
       
        [JsonIgnore]
        public List<Animal> Animals { get; set; }

        public Breed()
        {
            Animals = new List<Animal>();
        }
    }
}
