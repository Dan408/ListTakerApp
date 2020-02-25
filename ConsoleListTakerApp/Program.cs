using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleListTakerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NotMain notMain = new NotMain();
            IListTaker listTaker = new NotMain();

            Console.WriteLine(" Hello World!\n This List Taker app can take a list separated by a space\n Dates can be entered with a backslash \\ or a forward slash / *Example: 1/20/2020* \n Phone numbers will need dashes *Example: 123-459-345*\n");

            listTaker.UserInputSorter(notMain._inputText);
            listTaker.DisplayLists();
        }
    }
}
