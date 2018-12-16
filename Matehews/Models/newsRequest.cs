

namespace Matehews.Models
{
    public class newsRequest
    {
        public User user{ get; set; }
        public News post{ get; set; }
        public newsRequest()
        {
            this.user = new User();
            this.post = new News();
        }
    }
}