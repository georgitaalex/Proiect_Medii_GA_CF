using System.Collections.Generic;

namespace WEB.Models
{
    public class Locatie
    {
        public int ID { get; set; }
        public string NumeSala { get; set; }

        public string Adresa { get; set; }

        public string Oras { get; set; }

        public ICollection<Sport>? Sporturi { get; set; }

    }
}
