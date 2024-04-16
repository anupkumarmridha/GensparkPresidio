using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibery
{
    internal interface IClientInteraction
    {
        void GetOrder();
        void GetPayment();
        
    }
}
