using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleListTakerApp
{
    class Program : IListTaker
    {
        List<string> UIPhoneNumbers = new List<string>();
        List<string> UIDates = new List<string>();
        List<string> UIWords = new List<string>();
        List<int> UINumbers = new List<int>();


        private string _inputText;

        string IListTaker.InputText { get => _inputText; set => _inputText = value; }
        void IListTaker.UserInputSorter(string UIText)
        {
            string[] CharCheck = { "-", "\\", "/" };

            UIText = Console.ReadLine();
            _inputText = UIText;

            string[] InputSorter = _inputText.Split(new char[] { ' ' });

            for (int i = 0; i < InputSorter.Count(); i++)
            {
                int BoolNum = 0;
                bool result = int.TryParse(InputSorter[i], out BoolNum);

                switch (result != false)
                {
                    case false:
                        switch (CharCheck)
                        {
                            case string[] _ when InputSorter[i].Contains("-"): UIPhoneNumbers.Add(InputSorter[i]); break;

                            case string[] _ when InputSorter[i].Contains("/"): UIDates.Add(InputSorter[i]); break;

                            default: UIWords.Add(InputSorter[i]); break;
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
            UIDates.OrderBy(x => x).ToList().ForEach(x => { Console.WriteLine(x); });
        }

        static void Main(string[] args)
        {

            Program program = new Program();
            IListTaker listTaker = new Program();

            Console.WriteLine("Hello World! \n");

            listTaker.UserInputSorter(program._inputText);
            listTaker.DisplayLists();
        }
    }

    interface IListTaker
    {
        string InputText { get; set; }
        void UserInputSorter(string text);
        void DisplayLists();
    }
}
