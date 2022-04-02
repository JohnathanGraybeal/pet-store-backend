using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class Preferences
    {
        [Key]
        public int KeyId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
