using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task0.Sources;

namespace task0
{
    class Program
    {
        static void Main(string[] args)
        {
            ActionStorage storage = new ActionStorage("input.txt", "output.txt");
            List<MathAction> actions = storage.GetAll().ToList();

            Calculator.Calculate(actions);

            storage.Save();
            Console.ReadLine();
        }
    }
}
