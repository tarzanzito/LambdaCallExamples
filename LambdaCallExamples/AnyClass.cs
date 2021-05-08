using System;
using System.Collections.Generic;
using System.Text;

namespace Candal
{
    class AnyClass
    {
        public static void Create(string a, AnyModel b)
        {
            System.Diagnostics.Debug.Print("Static Create =" + a + " " + b.name);
        }

        public void Create1()
        {
            System.Diagnostics.Debug.Print("Instance Create1");
        }

        public void Create1(string a, AnyModel b)
        {
            System.Diagnostics.Debug.Print("Instance Create2 =" + a + " " + b.name);
        }

        public void Create1(string a)
        {
            System.Diagnostics.Debug.Print("Instance Create3 =" + a);
        }

        public void Create1(AnyModel b)
        {
            System.Diagnostics.Debug.Print("Instance Create4 = " + b.name);
        }
    }
}
