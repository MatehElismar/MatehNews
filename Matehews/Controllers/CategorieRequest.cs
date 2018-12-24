using Matehews.Models;

namespace Matehews.Models
{
    public class CategorieRequest
    {
        public User user{ get; set; }
        public Categorie categorie{ get; set; }

        public string lastname { get; set; }
        public CategorieRequest()
        {
            this.user = new User();
            this.categorie = new Categorie();
        }
    }
}