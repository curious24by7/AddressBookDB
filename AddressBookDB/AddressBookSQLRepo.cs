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
        public bool AddDetails(AddressBookModel model)
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmnd = new SqlCommand("SpAddDetails", connection);
                    cmnd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmnd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmnd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmnd.Parameters.AddWithValue("@Address", model.Address);
                    cmnd.Parameters.AddWithValue("@City", model.City);
                    cmnd.Parameters.AddWithValue("@State", model.State);
                    cmnd.Parameters.AddWithValue("@Zip", model.Zip);
                    cmnd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmnd.Parameters.AddWithValue("@Email", model.Email);
                    cmnd.Parameters.AddWithValue("@Type", model.Type);
                    cmnd.Parameters.AddWithValue("@AddressBookName", model.AddressBookName);
                    connection.Open();
                    var result = cmnd.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}
