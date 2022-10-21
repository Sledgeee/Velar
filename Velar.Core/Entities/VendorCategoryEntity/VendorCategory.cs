using Velar.Core.Entities.CategoryEntity;
using Velar.Core.Entities.VendorEntity;

namespace Velar.Core.Entities.VendorCategoryEntity
{
    public class VendorCategory
    {
        public int CategoryId { get; set; }
        public int VendorId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}