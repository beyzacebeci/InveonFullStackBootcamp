using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class BeforeISP
    {
        public interface IMachine
        {
            void Print();
            void Scan();
        }

        public class Printer : IMachine
        {
            public void Print()
            {
                Console.WriteLine("printing document");
            }

            public void Scan()
            {
                throw new NotImplementedException("printer can't scan");
            }
        }

        public class Scanner : IMachine
        {
            public void Print()
            {
                throw new NotImplementedException("scanner can't print.");
            }

            public void Scan()
            {
                Console.WriteLine("scanning document");
            }
        }
    }
}
