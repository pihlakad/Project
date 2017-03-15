using System;
using Logic;
using Logic.StandardUnits;

namespace Project {
    class Program {
        static void Main(string[] args) {
            var length1 = new Quantity(19, LengthUnits.Meter);
            var length2 = new Quantity(2, LengthUnits.KiloMeter);

            Console.WriteLine(length1 + length2); // 2019 m
            Console.WriteLine(length1);
            Console.WriteLine(length2);

            var speed = new Quantity(120, LengthUnits.KiloMeter / TimeUnits.Hour);

            Console.WriteLine(speed); // 120 km/h

            Console.ReadLine();
        }
    }
}
