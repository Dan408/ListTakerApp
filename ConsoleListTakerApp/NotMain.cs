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
        List<long> UINumbers = new List<long>();
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
            _inputText = Console.ReadLine();
        }


        void IListTaker.ParseList()
        {
            _parseInput = _inputText.Split(new char[] { ' ' });
        }

        void IListTaker.AllocateToLists(string UIText)
        {
            long t = 0; ;

            string[] CharCheck = { "-", "\\", "/" };
            _parseInput.ToList().ForEach(x => { if (x.Contains('-')) long.TryParse(x, out t); UINumbers.Add(t); });
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


        //void Empty()
        //{
        //    void IListTaker.AllocateToLists(string UIText)
        //{
        //        string[] CharCheck = { "-", "\\", "/" };

        //        for (int i = 0; i < _parseInput.Count(); i++)
        //        {
        //            int BoolNum = 0;
        //            bool result = int.TryParse(_parseInput[i], out BoolNum);

        //            switch (result != false)
        //            {
        //                case false:
        //                    switch (CharCheck) //check if string contains specified char
        //                    {
        //                        case string[] _ when _parseInput[i].Contains("-"): UIPhoneNumbers.Add(_parseInput[i]); break;
        //                        case string[] _ when _parseInput[i].Contains("/"): UIDates.Add(_parseInput[i]); break;
        //                        default: UIWords.Add(_parseInput[i]); break;
        //                    }
        //                    break;
        //                case true: UINumbers.Add(BoolNum); break;
        //            }

        //            int MinDigits = 0;

        //            foreach (char c in _parseInput[i])
        //            {

        //                if (char.IsNumber(c))
        //                {
        //                    MinDigits++;
        //                    if (MinDigits >= 9 & CharCheck.Contains(c)) { UIPhoneNumbers.Add(_parseInput[i]); }
        //                    if (MinDigits <= 8 & CharCheck.Contains(c)) { UIDates.Add(_parseInput[i]); }
        //                    if (result == true) { UINumbers.Add(BoolNum); }
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion
    }
}
