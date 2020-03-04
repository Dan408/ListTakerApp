using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleListTakerApp
{
    interface IListTaker
    {
        string InputText { get; set; }
        void AllocateToLists(string text);
        void DisplayLists();
        void DeleteDuplicates();
        void ExportJson();

        void GetList();

        void ParseList();



        string[] ParseInput { get; set; }

    }
}
