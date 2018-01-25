using System;

namespace Nile.Host
{
    class Program
    {
        static void Main( string[] args )
        {
            
        }

        static void PlayingWithPriimitives ()
        {
            //Primitive
            decimal unitPrice = 10.5M;

            //Real declaration
            //System.Decimal unitPrice2 = 10.5M;
            Decimal unitPrice2 = 10.5M;
            
            //Current time
            DateTime now = DateTime.Now;

            System.Collections.ArrayList items;
        }
        static void PlayingWithVariables ()
        {
            //note: don't use single letters as decls like x,y, and z.

            //Single decls
            int hours = 0;
            //Don't do this ( int hours; hours = 0; )

            double rate = 10.25;

            //Still not assigned
            //if (false)
            //hours = 0;

            int hours2 = hours;

            //Multiple decls
            string firstName, lastName;

            //Don't do this! ( string @class; )

            //Single assignment
            firstName = "Bob";
            lastName = "Miller";

            //Multiple assignment
            firstName = lastName = "Sue";

            //Math ops
            int x = 0, y = 10;
            int add = x + y;
            int subract = x - y;
            int multiply = x * y;
            int divide = x / y;
            int modulos = x % y;

            //x - x+10;
            x += 10;
            double ceiling = Math.Ceiling(rate);
            double floor = ceiling;
        }
    }
}
