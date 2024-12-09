using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class BeforeLSP
    {
        public class Bird
        {
            public virtual void Fly()
            {
                Console.WriteLine("flying in the sky.");
            }
        }

        public class Penguin : Bird
        {
            public override void Fly()
            {
                throw new NotSupportedException("penguins cant fly");
            }
        }
    }
}
