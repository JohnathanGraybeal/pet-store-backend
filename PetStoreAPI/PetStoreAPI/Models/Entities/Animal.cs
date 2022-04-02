using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class Animal: IValidatableObject
    {
        [Column("AnimalId")]
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateBorn { get; set; }
        [SwaggerSchema("The animals gender: Male, Female, or Unknown")]
        public string Gender { get; set; }
       
        public string Registered { get; set; }
       
        public string Color { get; set; }
        [DataType(DataType.Currency)]
        public Decimal ListPrice { get; set; }
        public byte[] Photo { get; set; }
    
        public string ImageFile { get; set; }
       
        public string ImageWidth { get; set; }//this is just to make sql server happy 
       
        public string ImageHeight { get; set; }

        //Navigation props

        [Column("Breed"), MaxLength(50)]
        public string BreedCategory { get; set; }
        [MaxLength(50)]
        public string Category { get; set; }
        [ForeignKey("BreedCategory, Category")]
        public  Breed Breed { get; set; }
      
       // public Category Category{ get; set; }
        [JsonIgnore]
        public SaleAnimal SaleAnimal { get; set; }

        [JsonIgnore]
        public List<AnimalOrderItem> AnimalOrderItems { get; set; }

        public Animal()
        {
            AnimalOrderItems = new List<AnimalOrderItem>();
        }
        






        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            
            if (Gender.ToUpper() != "MALE" && Gender.ToUpper() != "FEMALE" && Gender.ToUpper() != "UNKNOWN")
            {
                results.Add(new ValidationResult("Gender should be Male, Female, or Unknown", new[] { "Gender" }));
            }
            return results;
        }
    }
}
