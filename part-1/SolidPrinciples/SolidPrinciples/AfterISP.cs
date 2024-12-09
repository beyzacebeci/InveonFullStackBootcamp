using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class AfterISP
    {
        public interface IPrinter
        {
            void Print();
        }

        public interface IScanner
        {
            void Scan();
        }

        public class Printer : IPrinter
        {
            public void Print()
            {
                Console.WriteLine("printing document");
            }
        }

        public class Scanner : IScanner
        {
            public void Scan()
            {
                Console.WriteLine("scanning document");
            }
        }

        public class MultiFunctionPrinter : IPrinter, IScanner
        {
            public void Print()
            {
                Console.WriteLine("printing document");
            }

            public void Scan()
            {
                Console.WriteLine("scanning document");
            }
        }
    }
}
