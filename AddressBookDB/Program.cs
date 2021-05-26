using System;

namespace AddressBookDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Welcome to AddressBookDB !");
            AddressBookSQLRepo repo = new AddressBookSQLRepo();
            repo.GetDetails();
            Console.ReadKey();
        }
    }
}
