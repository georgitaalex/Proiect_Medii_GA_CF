using System.Collections.Generic;

namespace WEB.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<CategorieSport>? CategoriiSport { get; set; }
    }
}
