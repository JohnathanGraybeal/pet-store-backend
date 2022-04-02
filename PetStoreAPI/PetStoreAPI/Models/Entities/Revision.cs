using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Models.Entities
{
    public class Revision
    {
        [Column("RevisionId")]
        public int Id { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
