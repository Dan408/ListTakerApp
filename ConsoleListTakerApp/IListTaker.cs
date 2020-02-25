using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleListTakerApp
{
    interface IListTaker
    {
        string InputText { get; set; }
        void UserInputSorter(string text);
        void DisplayLists();
    }
}
