using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class program {
        public static void Main(string[] args)
        {
            Mon mon = new Mon();
            Child child = new Child();
            mon.eat += child.eat;
            mon.cook();
        }
    }
    class Mon {
        public event Action eat;
        public void cook()
        {
            Console.WriteLine("cook");
            eat.Invoke();
        }
    }
    class Child{
        public void eat() {
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }


}
