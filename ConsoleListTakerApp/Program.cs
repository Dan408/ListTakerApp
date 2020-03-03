using System;

namespace ConsoleListTakerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NotMain notMain = new NotMain();
            IListTaker listTaker = new NotMain();


            listTaker.AllocateToLists(notMain._inputText);
            listTaker.DeleteDuplicates();
            listTaker.DisplayLists();

            Console.WriteLine("\nEXPORTING JSON");

            listTaker.ExportJson();
        }
    }
}
