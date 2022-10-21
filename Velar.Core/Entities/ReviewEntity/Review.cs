using Velar.Core.Entities.ProductEntity;
using Velar.Core.Entities.UserEntity;

namespace Velar.Core.Entities.ReviewEntity
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Stars { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int ProductId { get; set; }
        public string? UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}