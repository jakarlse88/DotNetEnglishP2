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
        /// <returns>A List<Product> containing all products in the inventory.</returns>
        // JON KARLSEN:
        // Changed the return type of GetAllProducts() from array to List<Product>.
        // Corrected "product" to "products" above. 
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Attempts to find a product in the inventory by its ID. Returns the 
        /// product if found, else returns null.
        /// </summary>
        /// <param name="id">The ID of the product to find.</param>
        /// <returns>The located product, or null.</returns>
        // JON KARLSEN:
        // Implemented this method in the product repository to avoid having to 
        // retrieve a potentially very sizeable list every time a product is searched for, 
        // in the case of a real-life database.
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending on their ordered quantities
        /// </summary>
        /// <param name="cart">The cart whose products and quantities will be used to update the inventory.</param>
        public void UpdateProductQuantities(Cart cart)
        {
            // update product inventory by using _productRepository.UpdateProductStocks() method.
            foreach (CartLine line in cart.Lines)
            {
                _productRepository.UpdateProductStocks(line.Product.Id, line.Quantity);
            }
        }
    }
}
