using System;
using Logic;

namespace Project {
    class Program {
        static void Main(string[] args) {
            var length1 = new Quantity(19, LengthUnits.Meter);
            var length2 = new Quantity(2, LengthUnits.KiloMeter);

            Console.WriteLine(length1 + length2); // 2019 m
            Console.WriteLine(length1);
            Console.WriteLine(length2);

            Console.ReadLine();
        }
    }
}
