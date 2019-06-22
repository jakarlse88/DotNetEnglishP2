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

        public IProductRepository ProductRepository => _productRepository;

        /// <summary>
        /// Get all products from the inventory
        /// </summary>
        // JON KARLSEN:
        // Changed the return type of GetAllProducts() from array to List<Product>.
        // Corrected "product" to "products" above. 
        public List<Product> GetAllProducts()
        {
            return ProductRepository.GetAllProducts();
        }

        /// <summary>
        /// Get a product from the inventory by its id
        /// </summary>
        // JON KARLSEN:
        // Implemented this method in the product repository to avoid having to 
        // retrieve a potentially very sizeable list, in the case of a real-life database.
        public Product GetProductById(int id)
        {
            return ProductRepository.GetProductById(id);
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
