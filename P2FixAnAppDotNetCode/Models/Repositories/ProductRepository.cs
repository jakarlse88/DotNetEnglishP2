using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    /// <summary>
    /// The class that manages product data
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products;

        public ProductRepository()
        {
            // Only instantiate the list of product and generate initial data 
            // for the first class instantiation
            if (_products == null)
            {
                _products = new List<Product>();
                GenerateProductData();
            }
        }

        /// <summary>
        /// Generate the default list of products
        /// </summary>
        private void GenerateProductData()
        {
            int id = 0;
            _products.Add(new Product(++id, 10, 92.50, "Echo Dot", "(2nd Generation) - Black"));
            _products.Add(new Product(++id, 20, 9.99, "Anker 3ft / 0.9m Nylon Braided", "Tangle-Free Micro USB Cable"));
            _products.Add(new Product(++id, 30, 69.99, "JVC HAFX8R Headphone", "Riptidz, In-Ear"));
            _products.Add(new Product(++id, 40, 32.50, "VTech CS6114 DECT 6.0", "Cordless Phone"));
            _products.Add(new Product(++id, 50, 895.00, "NOKIA OEM BL-5J", "Cell Phone "));
        }

        /// <summary>
        /// Get all products with a non-zero stock from the inventory
        /// </summary>
        /// <returns>A List of products with non-zero inventory stock.</returns>
        // JON KARLSEN:
        // Changed return type from Product[] to List<Product>.
        public List<Product> GetAllProducts()
        {
            List<Product> list = 
                _products
                .Where(p => p.Stock > 0)
                .OrderBy(p => p.Name)
                .ToList();

            return list;
        }

        /// <summary>
        /// Update the stock of a product in the inventory by its id
        /// </summary>
        public void UpdateProductStocks(int productId, int quantityToRemove)
        {
            Product product = _products.First(p => p.Id == productId);
            product.Stock -= quantityToRemove; // Change to compound assignment

            if (product.Stock == 0)
                _products.Remove(product);
        }

        /// <summary>
        /// Attempts to find a product in the inventory by its ID. Returns the 
        /// product if found, else returns null.
        /// </summary>
        /// <param name="id">The ID of the product to find.</param>
        /// <returns>The located product, or null.</returns>
        // JON KARLSEN:
        // Corrected "form" to "from" above. 
        // Implemented the method.
        public Product GetProductById(int id)
        {
            // Find the product in the list by ID.
            // If a product by that ID is not found, product is null.
            Product product = _products.FirstOrDefault(prod => prod.Id == id);

            return product;
        }
    }
}
