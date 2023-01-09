using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WEB.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        public string Nume { get; set; }

        public string Prenume { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }

        public int Varsta{ get; set; }

        public int Experienta { get; set; }

        public ICollection<Sport>? Sporturi { get; set; }
        public ICollection<Instructor>? Instructori { get; set; }

    }
}
