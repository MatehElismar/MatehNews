

namespace Matehews.Models
{
    public class commentRequest
    {
        public User user{ get; set; }
        public Comment comment{ get; set; }
        public commentRequest()
        {
            this.user = new User();
            this.comment = new Comment();
        }
    }
}