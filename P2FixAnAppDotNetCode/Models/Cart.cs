using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// The list of cart lines -- ie. the orders in the cart.
        /// </summary>
        // JON KARLSEN:
        // Implemented this.
        private List<CartLine> _cartLineList;

        /// <summary>
        /// Read-only property for display only
        /// </summary>
        // JON KARLSEN:
        // Corrected "dispaly" to "display" above. 
        public IEnumerable<CartLine> Lines => _cartLineList;

        // JON KARLSEN: 
        // Add ctor to initialise list of cartlines
        public Cart()
        {
            _cartLineList = new List<CartLine>();
        }

        /// <summary>
        /// Adds a product in the cart, or increments the quantity of a given 
        /// product if it is already present in the cart
        /// </summary>
        /// <param name="product">The product to be added to the cart</param>
        /// <param name="quantity">The quantity of a given product to be added to the cart</param>
        public void AddItem(Product product, int quantity)
        {
            // If the product arg is null, exit early
            if (product == null)
                return;

            // Attempt to find a given product in the cart -- 
            // if it's not found, this variable will be null
            CartLine cartLine = _cartLineList
                .FirstOrDefault(item => item.Product.Id == product.Id);

            // Product is already present in cart, increment quantity
            if (cartLine != null) 
            {
                cartLine.Quantity += quantity;
            }
            // Product is not present in cart; create and populate a new CartLine object
            // with relevant data and add to the list.
            else 
            {
                _cartLineList.Add(new CartLine
                {
                    OrderLineId = _cartLineList.Count + 1, // Increment the count to avoid an id of 0 for human readability
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        /// <summary>
        /// Remove a product from the cart
        /// </summary>
        /// <param name="product">The product to be removed from the cart</param>
        // JON KARLSEN:
        // Corrected "form" to "from" above.
        public void RemoveLine(Product product) =>
            _cartLineList.RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Gets the total value of a cart
        /// </summary>
        /// <returns>A double representing the total value of a cart.</returns>
        // JON KARLSEN:
        // Implemented the method
        public double GetTotalValue()
        {
            double result = 0;

            // If the cart is empty, the result is given
            if (_cartLineList.Count > 0)
            {
                // Iterate over the contents of the cart and add to the total
                // each product's price times its quantity in the cart
                foreach (CartLine line in _cartLineList)
                {
                    result += line.Product.Price * line.Quantity;
                }
            }

            return result;
        }


        /// <summary>
        /// Gets the average value of a cart
        /// </summary>
        /// <returns>A double representing the average value of a cart.</returns>
        // JON KARLSEN:
        // Implemented the method
        public double GetAverageValue()
        {
            double result = 0;
            int totalProducts = 0;

            // If the cart is empty, the result is given
            if (_cartLineList.Count > 0)
            {
                foreach (CartLine line in _cartLineList)
                {
                    // Iterate over the contents of the cart and add to the total
                    // each product's price times its quantity in the cart
                    result += line.Product.Price * line.Quantity;

                    // Keep track of the total quantity of products in the cart
                    totalProducts += line.Quantity;
                }  

                // Divide the total value by the quantity of products to get the price average
                result /= totalProducts;
            }

            return result;
        }

        /// <summary>
        /// Searches for a given product in the cart and returns it if found.
        /// If the product is not found, returns null. 
        /// </summary>
        /// <param name="productId">ID of the product being searched for.</param>
        /// <returns>Returns a Product, or null.</returns>
        // JON KARLSEN:
        // Implemented the method. 
        public Product FindProductInCartLines(int productId)
        {
            // Attempt to get the cartline whose product ID matches the ID we're looking for.
            // If not found, this will be null.
            CartLine cartLine =
                _cartLineList.FirstOrDefault(line => line.Product.Id == productId);

            // Cartline was found, return the actual product
            if (cartLine != null) 
            {
                return cartLine.Product;
            }
            // Cartline wasn't found, ie. the product is not in the cart
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a specified cartline by its index
        /// </summary>
        /// <param name="index">The index of the cartline to be returned</param>
        /// <returns></returns>
        // JON KARLSEN:
        // Changed the return statement to use GetCartLineList() rather than Lines
        public CartLine GetCartLineByIndex(int index)
        {
            return _cartLineList.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        // JON KARLSEN:
        // Changed this method to access the cartline list through property
        public void Clear()
        {
            _cartLineList.Clear();
        }
    }

    /// <summary>
    /// The CartLine class.
    /// </summary>
    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

