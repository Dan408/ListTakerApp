using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleListTakerApp
{
    class NotMain : IListTaker
    {
        #region Collection Lists
        List<string> UIPhoneNumbers = new List<string>();
        List<string> UIDates = new List<string>();
        List<string> UIWords = new List<string>();
        List<int> UINumbers = new List<int>();
        #endregion

        #region Public Variable
        public string _inputText;
        public string[] _parseInput;
        #endregion

        #region Interface Implementation
        string IListTaker.InputText { get => _inputText; set => _inputText = value; }
        string[] IListTaker.ParseInput { get => _parseInput; set => _parseInput = value; }

        void IListTaker.GetList()
        {
            Console.WriteLine(" Hello World!\n This List Taker app can take a list separated by a space\n Dates can be entered with a backslash \\, dash - or with a forward slash / *Example: 1/20/2020* \n Phone numbers will need dashes *Example: 123-459-345*\n");

            _inputText = Console.ReadLine();

        }

        void IListTaker.ParseList()
        {
            _parseInput = _inputText.Split(new char[] { ' ' }); //Take string, split by empty space and put contents into new collection


             // Variable to be used to check if specified char is in string

        }

        void IListTaker.AllocateToLists(string UIText)
        {
            string[] CharCheck = { "-", "\\", "/" };

            for (int i = 0; i < _parseInput.Count(); i++) //For loop to traverse contents in collection and add them to different collections depending on results
            {
                int BoolNum = 0;
                bool result = int.TryParse(_parseInput[i], out BoolNum); //Check if string is a number, if it is, result is true and value of int is assigned to boolnum

                if (_parseInput[i].Contains("-")) { UIPhoneNumbers.Add(_parseInput[i]);  }
                if (_parseInput[i].Contains("/")) { UIPhoneNumbers.Add(_parseInput[i]); }
                else (

                switch (result != false)
                {
                    case false:
                        switch (CharCheck) //check if string contains specified char
                        {
                            case string[] _ when _parseInput[i].Contains("-"): UIPhoneNumbers.Add(_parseInput[i]); break;
                            case string[] _ when _parseInput[i].Contains("/"): UIDates.Add(_parseInput[i]); break;
                            default: UIWords.Add(_parseInput[i]); break;
                        }
                        break;
                    case true: UINumbers.Add(BoolNum); break;
                }
            }

        }

        void IListTaker.DisplayLists()
        {
            Console.WriteLine("\nNumbers:");
            UINumbers.OrderBy(x => x).ToList().ForEach(x => { Console.WriteLine(x); });

            Console.WriteLine("\nWords:");
            UIWords.OrderBy(x => x).ToList().ForEach(x => { Console.WriteLine(x); });

            Console.WriteLine("\nPhone Numbers:");
            UIPhoneNumbers.OrderBy(x => x).ToList().ForEach(x => { Console.WriteLine(x); });

            Console.WriteLine("\nDates:");
            UIDates.OrderBy(x => DateTime.Parse(x)).ToList().ForEach(x => { Console.WriteLine(x); });

            //Display Lists
        }

        void IListTaker.DeleteDuplicates()
        {
            UINumbers = UINumbers.Distinct().ToList();
            UIWords = UIWords.Distinct().ToList();
            UIPhoneNumbers = UIPhoneNumbers.Distinct().ToList();
            UIDates = UIDates.Distinct().ToList();
        }

        void IListTaker.ExportJson()
        {
            Console.WriteLine(@"Please enter Path and file name: *Example C:\Users\Person\File.txt");
            string path = Console.ReadLine();

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Numbers = UINumbers,
                Words = UIWords,
                PhoneNumbers = UIPhoneNumbers,
                Dates = UIDates

            }, Formatting.Indented); //schema is correct as long as it's done by the serializer in one go instead of the previous 4 times in a row

            System.IO.File.WriteAllText(path, json);

        }
        #endregion
    }
}
