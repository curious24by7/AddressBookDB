using System;

namespace AddressBookDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Welcome to AddressBookDB !");
            AddressBookSQLRepo repo = new AddressBookSQLRepo();
            AddressBookModel enter = new AddressBookModel();
            repo.GetDetails();
            Console.ReadKey();
        }
    }
}
