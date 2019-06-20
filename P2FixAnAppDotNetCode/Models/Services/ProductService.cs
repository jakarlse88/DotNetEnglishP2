using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all products from the inventory
        /// </summary>
        // JON KARLSEN:
        // Changed the return type of GetAllProducts() from array to List<Product>.
        // Corrected "product" to "products" above. 
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get a product from the inventory by its id
        /// </summary>
        // JON KARLSEN:
        // Corrected "form" to "from" above. 
        // Implemented the method.
        public Product GetProductById(int id)
        {
            // Get the list of all products
            List<Product> productList = _productRepository.GetAllProducts();

            // Find the product in the list by ID.
            // If a product by that ID is not found, product is null.
            Product product = productList.Find(prod => prod.Id == id);
            
            return product;
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // TODO implement the method
            // update product inventory by using _productRepository.UpdateProductStocks() method.
        }
    }
}
