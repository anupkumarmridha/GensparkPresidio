using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Cart:IEquatable<Cart>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }//Navigation property

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();//Navigation property
        public double ShippingCharge { get; set; } = 0;
        public double totalOrderValue { get; set; } = 0;
        public double Discount { get; set; } = 0;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cart Id: {Id}");
            sb.AppendLine($"Customer Id: {CustomerId}");
            sb.AppendLine($"Customer Name: {Customer?.Name ?? "N/A"}");
            sb.AppendLine($"Total Order Value: {totalOrderValue}");
            sb.AppendLine($"Total Shipping Charge: {ShippingCharge}");
            sb.AppendLine($"Total Discount: {Discount}");

            if (CartItems != null && CartItems.Any())
            {
                sb.AppendLine("Cart Items:");
                foreach (var cartItem in CartItems)
                {
                    sb.AppendLine(cartItem.ToString());
                }
            }
            else
            {
                sb.AppendLine("No items in the cart.");
            }

            return sb.ToString();
        }
        public bool Equals(Cart? other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}
