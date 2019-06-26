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
        // Note: this method currently exists only to satisfy tests (which cannot be changed)
        // and should not be used. 
        public List<CartLine> Lines => GetCartLineList();

        // JON KARLSEN:
        // Implemented this property for class-internal use. 
        private List<CartLine> CartLineList { get => _cartLineList; }

        // JON KARLSEN: 
        // Add a custom default ctor to initialise the list of cartlines,
        // and to keep track of the current orderline id.
        public Cart()
        {
            _cartLineList = new List<CartLine>();
        }

        /// <summary>
        /// Return a shallow copy of the actual cartline list
        /// </summary>
        /// <returns></returns>
        // JON KARLSEN:
        // This method previously always returned a new list;
        // changed it to return a shallow copy of the one list maintained by the class 
        // to maintain encapsulation. 
        private List<CartLine> GetCartLineList()
        {
            return CartLineList.ToList();
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>
        // JON KARLSEN: 
        // Implement the method
        public void AddItem(Product product, int quantity)
        {
            // Attempt to find a given product in the cart -- 
            // if it's not found, this variable will be null
            CartLine cartLine = CartLineList.FirstOrDefault(item => item.Product.Id == product.Id);

            // Product is already present in cart, increment quantity
            if (cartLine != null) 
            {
                cartLine.Quantity += quantity;
            }
            // Product is not present in cart; create and populate a new CartLine object
            // with relevant data and add to the list.
            else 
            {
                CartLineList.Add(new CartLine
                {
                    OrderLineId = CartLineList.Count + 1, // Increment the count to avoid an id of 0 for human readability
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        /// <summary>
        /// Removes a product from the cart
        /// </summary>
        // JON KARLSEN:
        // Corrected "form" to "from" above.
        public void RemoveLine(Product product) =>
            CartLineList.RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        // JON KARLSEN:
        // Implement the method
        public double GetTotalValue()
        {
            List<CartLine> cartLines = CartLineList;
            double result = 0;

            // If the cart is empty, the result is given
            if (cartLines.Count > 0)
            {
                // Iterate over the contents of the cart and add to the total
                // each product's price times its quantity in the cart
                foreach (CartLine line in cartLines)
                {
                    result += line.Product.Price * line.Quantity;
                }
            }

            return result;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        // JON KARLSEN:
        // Implemented the method
        public double GetAverageValue()
        {
            // Get the current cart contents
            List<CartLine> cartLines = CartLineList;
            double result = 0;
            int totalProducts = 0;

            // If the cart is empty, the result is given
            if (cartLines.Count > 0)
            {
                foreach (CartLine line in cartLines)
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
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        // JON KARLSEN:
        // Implemented the method. 
        public Product FindProductInCartLines(int productId)
        {
            // Get the list of cartlines
            List<CartLine> cartLineList = CartLineList;

            // Get the cartline whose product ID matches the ID we're looking for
            CartLine cartLine =
                cartLineList.FirstOrDefault(line => line.Product.Id == productId);

            // Get the actual product from that cartline
            Product product = cartLine.Product;
            return product;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        // JON KARLSEN:
        // Changed the return statement to use GetCartLineList() rather than Lines
        public CartLine GetCartLineByIndex(int index)
        {
            return CartLineList.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        // JON KARLSEN:
        // Changed this method to access the cartline list through property
        public void Clear()
        {
            CartLineList.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

