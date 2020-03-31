using System;
using System.Collections.Generic;
using System.Text;

namespace ArgModifiers
{
    static class InOutModifiers
    {
        public static void RunIn()
        {
            In(10);
        }

        //In modifier makes argument readonly and in case of non-managed memory improves performance.
        static void In(in int a)
        {
            System.Console.WriteLine($"In: {a}");
            //a = 2;
            //Can't change value because of in modificator, but it's possible to change content of referenced object.
        }

        public static void RunOut()
        {
            OutTest(1);
            OutTest(10);
        }
        static void OutTest(in int a)
        {
            //Out modifier declares output variable from function to use in parallel with returned value.
            if (Out(a, out int b))
            {
                System.Console.WriteLine($"OutTest returned true: {b}");
            }
            else
            {
                System.Console.WriteLine($"OutTest returned false: {b}");
            }
        }

        static bool Out(in int a, out int b)
        {
            b = -1;
            if (a < 2)
                return false;
            b = a * a;
            return true;
        }
    }
}
