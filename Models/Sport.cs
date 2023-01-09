using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WEB.Models
{
    public class Sport
    {
        public int ID { get; set; }


        [Display(Name = "Nume Sport")]
        public string NumeSport { get; set; }

        [Display(Name = "Nume Instructor")]
        public int? InstructorID { get; set; }
        public Instructor? Instructor { get; set; }


        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        public int? LocatieID { get; set; }
        public Locatie? Locatie { get; set; }

        public ICollection<CategorieSport>? CategoriiSport { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Durata { get; set; }
    }
}
