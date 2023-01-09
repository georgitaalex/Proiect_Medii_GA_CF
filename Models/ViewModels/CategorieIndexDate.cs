using System.Collections.Generic;

namespace WEB.Models.ViewModels
{
    public class CategorieIndexDate
    {
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<Sport> Sporturi { get; set; }
    }
}
