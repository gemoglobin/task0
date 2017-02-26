using System.Collections.Generic;
using System.IO;
using task0.Sources.interfaces;

namespace task0.Sources
{
    class ActionStorage : IStorage<MathAction>
    {
        List<MathAction> _actions;
        List<Operation> _operations;

        StreamReader inputfile;
        StreamWriter outputFile;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="inputFileNime">Имя входного файла</param>
        /// <param name="outputFileNime">Имя результирующего файла</param>
        /// <param name="operations">Список операций</param>
        public ActionStorage(string inputFileNime, string outputFileNime, List<Operation> operations)
        {
            _operations = operations;
            inputfile = new StreamReader(inputFileNime);
            outputFile = new StreamWriter(outputFileNime);
        }

        /// <summary>
        /// Возвращает список мат. действий
        /// </summary>
        /// <returns>Список мат. действий</returns>
        public IEnumerable<MathAction> GetAll()
        {
            _actions = new List<MathAction>();

            string line;

            while (!string.IsNullOrWhiteSpace(line = inputfile.ReadLine()))
            { 
                MathAction action = new MathAction();
                action.inputRow = line;
                action.ParseInputString(_operations);

                if(action.ParseInputString(_operations))
                    _actions.Add(action);
            }
            inputfile.Close();

            return _actions;
        }

        /// <summary>
        /// Записывает результаты обработки в файл
        /// </summary>
        public void Save()
        {
            outputFile.WriteLine("Результат:");
            foreach (var act in _actions)
            {
                if(act.message == null)
                    outputFile.WriteLine(act.inputRow + "=" + act.result);
            }
            outputFile.WriteLine("Возрастание второго аргумента:");

            CmpROperand <MathAction> cmpR = new CmpROperand<MathAction>();
            _actions.Sort(cmpR);
            foreach (var act in _actions)
            {
                if (act.message == null)
                    outputFile.WriteLine(act.inputRow + "=" + act.result);
            }
            outputFile.WriteLine("Убывание результата:");

            CmpResult<MathAction> cmpResult = new CmpResult<MathAction>();
            _actions.Sort(cmpResult);
            foreach (var act in _actions)
            {
                if (act.message == null)
                    outputFile.WriteLine(act.inputRow + "=" + act.result);
            }
            outputFile.WriteLine("По действиям:");

            CmpOperation <MathAction> cmpOperation = new CmpOperation<MathAction>();
            _actions.Sort(cmpOperation);
            foreach (var act in _actions)
            {
                if (act.message == null)
                    outputFile.WriteLine(act.inputRow + "=" + act.result);
            }

            outputFile.Close();
        }
    }
}
