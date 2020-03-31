using System;
using System.Collections.Generic;
using System.Text;

namespace MultiInheritance
{
    interface A
    {
        //Interfaces can have default implementations
        public void WriteSomething()
        {
            System.Console.WriteLine($"Something A");
        }
    }
    interface B
    {
        //Interfaces can have static variables
        static string Value = "What's going on?";
        public void WriteSomething()
        {
            System.Console.WriteLine($"Something B, {Value}");
        }
    }
    class MultiInheriting : A, B
    {
        //check with public access modifier - overrides Interfaces defaults even if running casted at interface
        void WriteSomething()
        {
            System.Console.WriteLine($"Own Something");
        }
    }
    static class MultiInheritanceTests
    {
        public static void Run()
        {
            MultiInheriting x = new MultiInheriting();

            WriteSthA(x);
            (x as B).WriteSomething();
            B.Value = "Crazy code";
            (x as B).WriteSomething();

            //It's possible to implement local functions in functions
            static void WriteSthA(A a)
            {
                a.WriteSomething();
            }
        }
    }
}
