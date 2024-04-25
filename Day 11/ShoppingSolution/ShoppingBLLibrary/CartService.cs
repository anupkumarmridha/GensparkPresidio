using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartService : ICartService
    {
        private readonly IRepository<int, Cart> _cartRepository;
        private readonly IRepository<int, Product> _productRepository;
        private readonly IRepository<int, Customer> _customerRepository;

        public CartService(IRepository<int, Cart> cartRepository,
                           IRepository<int, Product> productRepository,
                           IRepository<int, Customer> customerRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }
        public Cart AddProductToCart(int customerId, int productId, int quantity)
        {
            
            Cart cart = GetOrCreateCartForCustomer(customerId);
            Product product = _productRepository.GetByKey(productId);
            if (product == null)
            {
                throw new NoProductWithGiveIdException(productId);
            }

            // Apply the maximum quantity rule
            if (quantity > 5)
            {
                throw new MaxQuantityExceededException();
            }

            if (product.QuantityInHand < quantity)
            {
                int _quantityInHand = product.QuantityInHand;
                string _productName = product.Name;
                throw new ProductQuantityNotAvailableException(_productName, _quantityInHand);
            }

            // Add the product to the cart
            CartItem cartItem = new CartItem
            {
                CartId = cart.Id,
                ProductId = productId,
                Product = product,
                Quantity = quantity,
                Price = product.Price,
                Discount = 0,
                PriceExpiryDate = DateTime.Today.AddDays(7)
            };
            cart.CartItems.Add(cartItem);
            
            double totalOrderValue = cart.CartItems.Sum(item => item.Price * item.Quantity);
            cart.totalOrderValue= totalOrderValue;

            // Apply shipping charge rule
            if (totalOrderValue < 100)
            {
                cart.ShippingCharge = 100;
            }
            // Apply discount rule
            if (cart.CartItems.Count >= 3 && totalOrderValue >= 1500)
            {
                double discountAmount = totalOrderValue * 0.05;
                cart.Discount = discountAmount;
            }

            Cart Updatedcart = _cartRepository.Update(cart);

            return Updatedcart;
        }

        public Cart RemoveProductFromCart(int cartId, int productId)
        {

            Cart cart = _cartRepository.GetByKey(cartId);
            if (cart == null)
            {
                throw new CartNotFoundException(cartId);
            }
            CartItem cartItemToRemove = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (cartItemToRemove == null)
            {
                throw new CartItemNotFoundException(productId);
            }
            cart.CartItems.Remove(cartItemToRemove);

            // Recalculate total order value
            double totalOrderValue = cart.CartItems.Sum(item => item.Price * item.Quantity);

            // Apply shipping charge rule
            if (totalOrderValue < 100)
            {
                cart.ShippingCharge = 100;
            }

            // Apply discount rule
            if (cart.CartItems.Count == 3 && totalOrderValue >= 1500)
            {
                double discountAmount = totalOrderValue * 0.05;
                cart.Discount = discountAmount;
            }

            Cart Updatedcart=_cartRepository.Update(cart);

            return Updatedcart;

        }

        public Cart UpdateCartItemQuantity(int cartId, int productId, int newQuantity)
        {
            Cart cart = _cartRepository.GetByKey(cartId);
            if (cart == null)
            {
                throw new CartNotFoundException(cartId);
            }
            CartItem cartItemToUpdate = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (cartItemToUpdate == null)
            {
                throw new CartItemNotFoundException(productId);
            }
            // Apply the maximum quantity rule
            if (newQuantity > 5)
            {
                throw new MaxQuantityExceededException(productId);
            }

            Product product = _productRepository.GetByKey(productId);
            if (product == null)
            {
                throw new NoProductWithGiveIdException(productId);
            }

            if (product.QuantityInHand < newQuantity)
            {
                int _quantityInHand = product.QuantityInHand;
                string _productName = product.Name;
                throw new ProductQuantityNotAvailableException(_productName, _quantityInHand);
            }

            cartItemToUpdate.Quantity = newQuantity;

            // Recalculate total order value
            double totalOrderValue = cart.CartItems.Sum(item => item.Price * item.Quantity);

            // Apply shipping charge rule
            if (totalOrderValue < 100)
            {
                cart.ShippingCharge = 100;
            }
            if (cart.CartItems.Count == 3 && totalOrderValue >= 1500)
            {
                double discountAmount = totalOrderValue * 0.05;
                cart.Discount = discountAmount;
            }
            Cart Updatedcart = _cartRepository.Update(cart);

            return Updatedcart;
        }

        public Cart GetCartById(int cartId)
        {
            Cart cart = _cartRepository.GetByKey(cartId);
            if (cart == null)
            {
                throw new CartNotFoundException(cartId);
            }
            return cart;
        }

        public List<Cart> GetAllCarts()
        {
            List<Cart> carts = _cartRepository.GetAll().ToList();
            return carts;
        }

        private Cart GetOrCreateCartForCustomer(int customerId)
        {
            // Try to retrieve the cart for the customer
            Cart cart = _cartRepository.GetAll().FirstOrDefault(c => c.CustomerId == customerId);
            Customer customer = _customerRepository.GetByKey(customerId);
            if (customer == null)
            {
                throw new NoCustomerWithGiveIdException(customerId);
            }

            if (cart == null)
            {
                cart = new Cart { CustomerId = customerId, Customer = customer };
                _cartRepository.Add(cart);
            }

            return cart;
        }

    }
}