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

        public static List<Product> Products { get => _products; set => _products = value; }

        public ProductRepository()
        {
            Products = new List<Product>();
            GenerateProductData();
        }

        /// <summary>
        /// Generate the default list of products
        /// </summary>
        private void GenerateProductData()
        {
            int id = 0;
            Products.Add(new Product(++id, 10, 92.50, "Echo Dot", "(2nd Generation) - Black"));
            Products.Add(new Product(++id, 20, 9.99, "Anker 3ft / 0.9m Nylon Braided", "Tangle-Free Micro USB Cable"));
            Products.Add(new Product(++id, 30, 69.99, "JVC HAFX8R Headphone", "Riptidz, In-Ear"));
            Products.Add(new Product(++id, 40, 32.50, "VTech CS6114 DECT 6.0", "Cordless Phone"));
            Products.Add(new Product(++id, 50, 895.00, "NOKIA OEM BL-5J", "Cell Phone "));
        }

        /// <summary>
        /// Get all products from the inventory
        /// </summary>
        // JON KARLSEN:
        // Changed return type from Product[] to List<Product>.
        public List<Product> GetAllProducts()
        {
            List<Product> list = Products.Where(p => p.Stock > 0).OrderBy(p => p.Name).ToList();
            // JON KARLSEN:
            // Changed return statement to reflect return type change. 
            return list;
        }

        /// <summary>
        /// Update the stock of a product in the inventory by its id
        /// </summary>
        public void UpdateProductStocks(int productId, int quantityToRemove)
        {
            Product product = Products.First(p => p.Id == productId);
            product.Stock = product.Stock - quantityToRemove;

            if (product.Stock == 0)
                Products.Remove(product);
        }

        /// <summary>
        /// Get a product from the inventory by its id
        /// </summary>
        // JON KARLSEN:
        // Corrected "form" to "from" above. 
        // Implemented the method.
        public Product GetProductById(int id)
        {
            // Find the product in the list by ID.
            // If a product by that ID is not found, product is null.
            Product product = Products.Find(prod => prod.Id == id);

            return product;
        }
    }
}
