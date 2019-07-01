using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        // JON KARLSEN:
        // Changed return type from Product[] to List<Product>.
        List<Product> GetAllProducts();

        void UpdateProductStocks(int productId, int quantityToRemove);

        // JON KARLSEN:
        // Add here since method is now implemented in the repository
        Product GetProductById(int id);
    }
}
