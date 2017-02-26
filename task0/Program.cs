using System;
using System.Collections.Generic;
using System.Linq;
using task0.Sources;

namespace task0
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Operation> operations = new List<Operation>
            {
                new Operation { _name = "сложение", _view = "+", _priority = 4 },
                new Operation { _name = "вычитание", _view = "-", _priority = 5 },
                new Operation { _name = "умножение", _view = "*", _priority = 2 },
                new Operation { _name = "деление", _view = "/", _priority = 3 },
                new Operation { _name = "нод", _view = "#", _priority = 6 },
                new Operation { _name = "возведение в степень", _view = "^", _priority = 1 }
            };

            ActionStorage storage = new ActionStorage("input.txt", "output.txt", operations);
            List<MathAction> actions = storage.GetAll().ToList();
            Calculator.Calculate(actions);            
            storage.Save();
        }
    }
}
