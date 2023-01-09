using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB.Data;
namespace WEB.Models
{
    public class CategorieSportPageModel : PageModel
    {
        public List<CategorieAtribuita> CategorieAtribuitaLista;
        public void PopuleazaCategorieAtribuita(WEBContext context,
        Sport sport)
        {
            var toateCategoriile = context.Categorie;
            var categoriiSport = new HashSet<int>(
            sport.CategoriiSport.Select(c => c.CategorieID)); //
            CategorieAtribuitaLista = new List<CategorieAtribuita>();
            foreach (var cat in toateCategoriile)
            {
                CategorieAtribuitaLista.Add(new CategorieAtribuita
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Atribut = categoriiSport.Contains(cat.ID)
                });
            }
        }
        public void UpdateCategoriiSport(WEBContext context,
        string[] selectedCategories, Sport bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.CategoriiSport = new List<CategorieSport>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var categoriiSport = new HashSet<int>
            (bookToUpdate.CategoriiSport.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!categoriiSport.Contains(cat.ID))
                    {
                        bookToUpdate.CategoriiSport.Add(
                        new CategorieSport
                        {
                            SportID = bookToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (categoriiSport.Contains(cat.ID))
                    {
                        CategorieSport courseToRemove
                        = bookToUpdate
                        .CategoriiSport
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

