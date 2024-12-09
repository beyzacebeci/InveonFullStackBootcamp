using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class BeforeOCP
    {
        public class Rectangle
        {
            public double Width { get; set; }
            public double Height { get; set; }
        }

        public class Circle
        {
            public double Radius { get; set; }
        }

        public class AreaCalculator
        {
            public double CalculateTotalArea(List<object> shapes)
            {
                double totalArea = 0;

                foreach (var shape in shapes)
                {
                    
                    if (shape is Rectangle rectangle)
                    {
                        totalArea += rectangle.Width * rectangle.Height;
                    }
                    else if (shape is Circle circle)
                    {
                      
                        totalArea += Math.PI * circle.Radius * circle.Radius;
                    }
                    else
                    {
                        throw new InvalidOperationException("unknown shape");
                    }
                }


                return totalArea;
            }
        }


    }
}
