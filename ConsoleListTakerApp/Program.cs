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
        

        string IListTaker.InputText { get => _inputText;  set => _inputText = value;  }
        void IListTaker.UserInput(string UIText)
        {
            string[] CharCheck = { "-", "\\", "/" };

            UIText = Console.ReadLine();
            _inputText = UIText;

            string[] InputSorter = _inputText.Split(new char[] {' ' });

            for (int i = 0; i < InputSorter.Count(); i++)
            {
                int BoolNum = 0;

                bool result = int.TryParse(InputSorter[i], out BoolNum);

                if (result != false) { UINumbers.Add(BoolNum); }
                else UIWords.Add(InputSorter[i]);

                switch(result  != false)
                {


                    case true : UINumbers.Add(BoolNum); return;


                }

                switch(CharCheck)
                {
                    case string[] a when a.Contains("-"): UIPhoneNumbers.Add(InputSorter[i]); return;

                    case string[] b when b.Contains("/"): UIDates.Add(InputSorter[i]); return;
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

            listTaker.UserInput(program._inputText);

            listTaker.DisplayLists();

            
        }
    }

    interface IListTaker
    {
        string InputText { get; set; }
        void UserInput(string text);

        void DisplayLists();
    }
}
