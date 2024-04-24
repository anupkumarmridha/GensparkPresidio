using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class CartItem: IEquatable<CartItem>
    {
        public int CartId { get; set; }//Navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; }//Navigation property
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }
        public override string ToString()
        {
            return $"Product: {Product.Name}, Quantity: {Quantity}, Price: {Price:C}, Discount: {Discount:C}, Price Expiry Date: {PriceExpiryDate}";
        }

        public bool Equals(CartItem? other)
        {
            return this.CartId.Equals(other.CartId);
        }

    }
}
