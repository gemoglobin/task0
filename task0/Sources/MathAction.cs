using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using task0.Sources.interfaces;

namespace task0.Sources
{
    public class MathAction
    {
        public string inputRow { get; set; }
        public int leftOperand { get; set; }
        public int rightOperand { get; set; }
        public Operation operation { get; set; }
        public int result { get; set; }

        public void ParseInputString(List<Operation> _operations)
        {
            string pattern = @"^\s*(\d+)\s*([-+*/^#])\s*(\d+)\s*$";

            foreach (Match m in Regex.Matches(inputRow, pattern))
            {
                int value1, value2;

                if (Int32.TryParse(m.Groups[1].Value, out value1))
                    leftOperand = value1;
                else
                    Console.WriteLine("Attempted conversion of '{0}' failed.", m.Groups[1].Value);

                if (Int32.TryParse(m.Groups[3].Value, out value2))
                    rightOperand = value2;
                else
                    Console.WriteLine("Attempted conversion of '{0}' failed.", m.Groups[3].Value);

                operation = _operations.Single(s => s._view == m.Groups[2].Value);
            }
        }
    }
}
