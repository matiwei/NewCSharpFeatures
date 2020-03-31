using System;

namespace ArgModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            InOutModifiers.RunIn();
            InOutModifiers.RunOut();
            
            RefModifier.RunValues();
            RefModifier.RunReferences();
        }
    }
}
