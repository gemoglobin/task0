using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task0.Sources.interfaces;

namespace task0.Sources
{
    class ActionStorage : IStorage<MathAction>
    {
        List<MathAction> _actions;
        List<Operation> _operations;

        StreamReader inputfile;
        StreamWriter outputFile;

        public ActionStorage(string inputFileNime, string outputFileNime, List<Operation> operations)
        {
            _operations = operations;
            inputfile = new StreamReader(inputFileNime);
            outputFile = new StreamWriter(outputFileNime);
        }

        public IEnumerable<MathAction> GetAll()
        {
            _actions = new List<MathAction>();

            string line;

            while ((line = inputfile.ReadLine()) != null)
            {
                MathAction action = new MathAction();
                action.inputRow = line;
                action.ParseInputString(_operations);

                if(action.operation != null)
                    _actions.Add(action);
            }
            inputfile.Close();

            return _actions;
        }

        public void Save()
        {
            foreach(var act in _actions)
            {
                if(act.operation != null)
                    outputFile.WriteLine(act.inputRow + "=" + act.result);
            }
            outputFile.WriteLine();
            outputFile.Close();
        }
    }
}
