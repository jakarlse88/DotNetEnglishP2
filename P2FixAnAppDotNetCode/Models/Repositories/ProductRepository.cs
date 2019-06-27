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
        private static List<Product> _oldProducts; // Persist the inventory across class instances

        // JON KARLSEN: 
        // Changed this property to private
        private static List<Product> Products { get => _products; set => _products = value; }
        private static List<Product> OldProducts { get => _oldProducts; set => _oldProducts = value; }

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
            Products.Add(new Product(++id, EvaluateProductStock(id, 10), 92.50, "Echo Dot", "(2nd Generation) - Black"));
            Products.Add(new Product(++id, EvaluateProductStock(id, 20), 9.99, "Anker 3ft / 0.9m Nylon Braided", "Tangle-Free Micro USB Cable"));
            Products.Add(new Product(++id, EvaluateProductStock(id, 30), 69.99, "JVC HAFX8R Headphone", "Riptidz, In-Ear"));
            Products.Add(new Product(++id, EvaluateProductStock(id, 40), 32.50, "VTech CS6114 DECT 6.0", "Cordless Phone"));
            Products.Add(new Product(++id, EvaluateProductStock(id, 50), 895.00, "NOKIA OEM BL-5J", "Cell Phone "));
        }

        /// <summary>
        /// Evaluate a given product's stock
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <param name="defaultStock">Default stock value</param>
        /// <returns></returns>
        private static int EvaluateProductStock(int id, int defaultStock)
        {
            // Use the product's actual stock value, or default to a default value
            // I suspect I'll get to change this line shortly,
            // but it sure is succint!
            return OldProducts?.FirstOrDefault(p => p.Id == id)?.Stock ?? defaultStock;
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
            product.Stock -= quantityToRemove; // Change to compound assignment

            if (product.Stock == 0)
                Products.Remove(product);

            // Set OldProducts to reference the current list of products,
            // facilitating product stock values persisting over repository instances
            OldProducts = Products;
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
