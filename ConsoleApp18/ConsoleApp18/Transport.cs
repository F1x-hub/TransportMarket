using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Transport
    {
        public int UserId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Engine { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer} - Model: {Model} - Year: {Year} - Engine: {Engine} - Price: {Price}";
        }
    }
}
