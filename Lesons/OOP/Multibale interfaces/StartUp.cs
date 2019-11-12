using System;

namespace Multibale_interfaces
{
    class StartUp
    {
        public interface IA
        {
            void M();
        }
        public interface IB
        {
            int M();
        }
        public class C : IA, IB
        {
            public int M()
            {
                throw new NotImplementedException();
            }

            //one of them is private!
            void IA.M()
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {
            //but we can use it liek this
            IA c = new C();
            c.M();
        }
    }
}
