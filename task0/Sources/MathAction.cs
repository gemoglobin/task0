using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace task0.Sources
{
    public class MathAction
    {
        public string inputRow { get; set; }
        public int leftOperand { get; set; }
        public int rightOperand { get; set; }
        public Operation operation { get; set; }
        public int result { get; set; }
        public string message { get; set; }

        /// <summary>
        /// Разбирает входную строку на операнды и операцию над ними
        /// </summary>
        /// <param name="_operations">список операций</param>
        /// <returns>true - успешно, false - ошибка разбора входной строки</returns>
        public bool ParseInputString(List<Operation> _operations)
        {
            string pattern = @"^\s*(\d+)\s*([-+*/^#])\s*(\d+)\s*$";

            Match m = Regex.Match(inputRow, pattern);
            if (m.Groups.Count == 4)
            {
                int value1, value2;

                if (Int32.TryParse(m.Groups[1].Value, out value1))
                    leftOperand = value1;
                else
                    return false;

                if (Int32.TryParse(m.Groups[3].Value, out value2))
                    rightOperand = value2;
                else
                    return false;

                operation = _operations.Single(s => s._view == m.Groups[2].Value);
            }
            else
                return false;

            return true;
        }
    }

    /// <summary>
    /// Класс реализует IComparer для сортировки действий по операциям
    /// </summary>
    /// <typeparam name="T">объект типа MathAction для сравнения</typeparam>
    class CmpOperation<T> : IComparer<T> where T : MathAction
    {
        public int Compare(T x, T y)
        {
            if (x.operation._priority < y.operation._priority)
                return -1;
            if (x.operation._priority > y.operation._priority)
                return 1;
            else return 0;
        }
    }

    /// <summary>
    /// Класс реализует IComparer для сортировки действий по возрастанию второго операнда
    /// </summary>
    /// <typeparam name="T"> объект типа MathAction для сравнения</typeparam>
    class CmpROperand<T> : IComparer<T> where T : MathAction
    {
        public int Compare(T x, T y)
        {
            if (x.rightOperand < y.rightOperand)
                return -1;
            if (x.rightOperand > y.rightOperand)
                return 1;
            else return 0;
        }
    }

    /// <summary>
    /// Класс реализует IComparer для сортировки действий по убыванию результата
    /// </summary>
    /// <typeparam name="T">объект типа MathAction для сравнения</typeparam>
    class CmpResult<T> : IComparer<T> where T : MathAction
    {
        public int Compare(T x, T y)
        {
            if (x.result < y.result)
                return 1;
            if (x.result > y.result)
                return -1;
            else return 0;
        }
    }
}
