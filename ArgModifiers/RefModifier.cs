using System;
using System.Collections.Generic;
using System.Text;

namespace ArgModifiers
{
    static class RefModifier
    {
        public static void RunValues()
        {
            int b = 10;
            ValueNoRef(b);
            System.Console.WriteLine($"ValueNoRef returned Value: {b}");
            ValueRef(ref b);
            System.Console.WriteLine($"ValueRef returned Value: {b}");
        }

        //Value types
        static void ValueNoRef(int a)
        {
            // a==10;
            a += 100;
            // a==110
            // a==10 in caller
        }
        static void ValueRef(ref int a)
        {
            // a==10
            a += 100;
            // a==110
            // a==110 in caller
        }

        public static void RunReferences()
        {
            var a = new HelperObject(10);
            NoRef(a);
            System.Console.WriteLine($"NoRef returned Value: {a?.Value}");
            Ref(ref a);
            System.Console.WriteLine($"Ref returned Value: {a?.Value}");
        }

        //Reference types
        static void NoRef(HelperObject a)
        {
            //a.Value == 10;
            a.Value = 17;
            //a.Value == 17;
            a = new HelperObject(25);
            //a.Value == 25;
            //a.Value == 17 in caller
        }
        static void Ref(ref HelperObject a)
        {
            //a.Value == 10;
            a.Value = 17;
            //a.Value == 17;
            a = new HelperObject(25);
            //a.Value == 25;
            //a.Value == 25 in caller, because reference is changed to new object also in caller
        }
    }
}
