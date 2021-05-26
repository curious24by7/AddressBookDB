using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookDB
{
    class AddressBookSQLRepo
    {
        public static string ConnectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=AddressbookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        readonly SqlConnection connection = new SqlConnection(ConnectionString);
        public void GetDetails()
        {
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"SELECT * FROM AddressBook ";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            addressBookModel.ID = reader.GetInt32(0);
                            addressBookModel.FirstName = reader.GetString(1);
                            addressBookModel.LastName = reader.GetString(2);
                            addressBookModel.Address = reader.GetString(3);
                            addressBookModel.City = reader.GetString(4);
                            addressBookModel.State = reader.GetString(5);
                            addressBookModel.Zip = reader.GetString(6);
                            addressBookModel.PhoneNumber = reader.GetString(7);
                            addressBookModel.Email = reader.GetString(8);
                            addressBookModel.Type = reader.GetString(9);
                            addressBookModel.AddressBookName = reader.GetString(11);
                            Console.WriteLine(addressBookModel.ID + " " + addressBookModel.FirstName + " " + addressBookModel.LastName + " " + addressBookModel.Address + " " + addressBookModel.City + " " + addressBookModel.State + " " + addressBookModel.Zip + " " + addressBookModel.PhoneNumber + " " + addressBookModel.Email + " " + addressBookModel.Type + " " + addressBookModel.AddressBookName);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
