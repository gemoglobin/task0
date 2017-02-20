using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task0.Sources.interfaces;

namespace task0.Sources
{
    public static class Calculator
    {
        public static void Calculate(List<MathAction> actions)
        {
            foreach (var act in actions)
            {
                switch (act.operation)
                {
                    case "+":
                        act.result = act.leftOperand + act.rightOperand;
                        break;
                    case "-":
                        act.result = act.leftOperand - act.rightOperand;
                        break;
                    case "*":
                        act.result = act.leftOperand * act.rightOperand;
                        break;
                    case "/":
                        if (act.rightOperand == 0)
                            act.result = int.MaxValue;
                        else
                            act.result = act.leftOperand / act.rightOperand;
                        break;
                    case "^":
                        act.result = (int)Math.Pow(act.leftOperand, act.rightOperand);
                        break;
                    case "#":
                        act.result = gcd(act.leftOperand, act.rightOperand);
                        break;
                }
            }
        }

        public static int gcd(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);
            return gcd(b, a % b);
        }
    }
}
