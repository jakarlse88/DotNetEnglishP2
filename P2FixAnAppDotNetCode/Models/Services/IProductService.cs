using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    public interface IProductService
    {
        // JON KARLSEN:
        // Changed return type from Product[] to List<Product>.
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void UpdateProductQuantities(Cart cart);
    }
}
