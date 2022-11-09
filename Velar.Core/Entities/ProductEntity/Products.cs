using Ardalis.Specification;

namespace Velar.Core.Entities.ProductEntity
{
    public class Products
    {
        internal class ProductsBySpec : Specification<Product>
        {
            public ProductsBySpec(int categoryId = -1)
            {
                if (categoryId > -1)
                {
                    Query.Where(x => x.CategoryId == categoryId).OrderByDescending(x => x.ProductId);
                }
                else
                {
                    Query.OrderByDescending(x => x.ProductId);
                }
            }

            public ProductsBySpec(string searchTerm)
            {
                Query.Search(x => x.Name, searchTerm);
            }
        }
    }
}