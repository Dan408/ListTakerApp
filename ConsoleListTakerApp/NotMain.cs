﻿using Newtonsoft.Json;
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
        #endregion

        #region Interface Implementation
        string IListTaker.InputText { get => _inputText; set => _inputText = value; }
        void IListTaker.UserInputSorter(string UIText)
        {
            UIText = Console.ReadLine();
            _inputText = UIText;
            //Read user input and put into a variable

            string[] InputSorter = _inputText.Split(new char[] { ' ' }); //Take string, split by empty space and put contents into new collection


            string[] CharCheck = { "-", "\\", "/" };  // Variable to be used to check if specified char is in string

            for (int i = 0; i < InputSorter.Count(); i++) //For loop to traverse contents in collection and add them to different collections depending on results
            {
                int BoolNum = 0;
                bool result = int.TryParse(InputSorter[i], out BoolNum); //Check if string is a number, if it is, result is true and value of int is assigned to boolnum

                switch (result != false)
                {
                    case false:
                        switch (CharCheck) //check if string contains specified char
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

            }, Formatting.Indented);

            System.IO.File.WriteAllText(path, json);

        }
        #endregion
    }
}
