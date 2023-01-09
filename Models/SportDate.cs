using System.Collections.Generic;

namespace WEB.Models
{
    public class SportDate
    {
        public IEnumerable<Sport> Sporturi { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieSport> CategoriiSport { get; set; }
    }
}
