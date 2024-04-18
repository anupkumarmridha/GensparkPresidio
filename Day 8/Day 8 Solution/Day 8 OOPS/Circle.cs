using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8_OOPS
{
    internal class Circle:Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drwaing a circle");
            base.Draw();    
        }
    }
}
