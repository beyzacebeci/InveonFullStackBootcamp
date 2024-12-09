using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class AfterLSP
    {
        public abstract class Bird
        {
            public abstract void Move();
        }

        public class Sparrow : Bird
        {
            public override void Move()
            {
                Console.WriteLine("flying in the sky");
            }
        }

        public class Penguin : Bird
        {
            public override void Move()
            {
                Console.WriteLine("waddling on the ground");
            }
        }

    }
}
