namespace WEB.Models
{
    public class CategorieSport
    {
        public int ID { get; set; }
        public int SportID { get; set; }
        public Sport Sport { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
