using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        private List<CartLine> cartLineList;
        private int currentOrderLineId;

        /// <summary>
        /// Read-only property for display only
        /// </summary>
        // JON KARLSEN:
        // Corrected "dispaly" to "display" above. 
        public IEnumerable<CartLine> Lines => GetCartLineList();

        private List<CartLine> CartLineList { get => cartLineList; set => cartLineList = value; }
        public int CurrentOrderLineId { get => currentOrderLineId; set => currentOrderLineId = value; }

        // JON KARLSEN:
        // Add a custom default ctor to initialise the list of cartlines,
        // and to keep track of the current orderline id.
        public Cart()
        {
            CartLineList = new List<CartLine>();
            CurrentOrderLineId = 0;
        }

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        // JON KARLSEN:
        // This method previously always returned a new list;
        // changed it to return the one list maintained by the class.
        private List<CartLine> GetCartLineList()
        {
            return CartLineList;
        }

        private int GetCurrentOrderLineIdAndIncrement()
        {
            CurrentOrderLineId++;
            return CurrentOrderLineId;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>
        // JON KARLSEN:
        // 
        public void AddItem(Product product, int quantity)
        {
            // Attempt to find the index of the given product in the cart. 
            // If the product is present, the index will be > -1.
            int cartLineIdx = GetCartLineList().FindIndex(item => item.Product.Id == product.Id);

            // Product is present already in cart, increment quantity
            if (cartLineIdx > -1) 
            {
                cartLineList[cartLineIdx].Quantity += quantity;
            }
            // Product is not present in cart; create and populate a new CartLine object
            // with relevant data and add to the list.
            else 
            {
                CartLine cartLine = new CartLine
                {
                    OrderLineId = GetCurrentOrderLineIdAndIncrement(),
                    Product = product,
                    Quantity = quantity
                };

                cartLineList.Add(cartLine);
            }
        }

        /// <summary>
        /// Removes a product from the cart
        /// </summary>
        // JON KARLSEN:
        // Corrected "form" to "from" above.
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        // JON KARLSEN:
        // Implemented the method. 
        public Product FindProductInCartLines(int productId)
        {
            // Get the list of cartlines
            List<CartLine> cartLineList = GetCartLineList();

            // Get the cartline whose product matches the ID we're looking for
            CartLine cartLine =
                cartLineList.FirstOrDefault(line => line.Product.Id == productId);

            // Get the actual product from that cartline
            Product product = cartLine.Product;
            return product;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}