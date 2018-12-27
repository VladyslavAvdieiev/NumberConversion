using System;
using NumberConversion;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ConsoleApp
{
    class Program {

        static void Main(string[] args) {
            Console.WriteLine("[Application can convert integer (10) and fraction (10,5) numbers]\n");

            try {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Current number system [2-36]: ");
                int currentSystem = int.Parse(Console.ReadLine());
                Console.Write("Needed number system [2-36]: ");
                int neededSystem = int.Parse(Console.ReadLine());
                Console.Write("Number: ");
                string number = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Answer: {NumberConverterService.Convert(number, currentSystem, neededSystem)}");
            }
            catch (Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error]: {e.Message}");
            }

            Console.ReadLine();
        }
    }
}
