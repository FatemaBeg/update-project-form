using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ProectWindowsFormsApp1.Model;

namespace ProectWindowsFormsApp1.Repository
{
    public class CustomerRepository
    {
        public bool AddCustomer(Customers customer)
        {
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"INSERT INTO Customers (Code, Name, Address, Email,Contact, LoyaltyP) VALUES('" + customer.Code + "', '" + customer.Name + "', '"  + customer.Address + "', '" + customer.Email + "', '" + customer.Contact + "', '" + customer.LoyaltyP + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isAdded = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (isAdded > 0)
                return true;
            else
                return false;
        }

        //public bool UpdateCustomer(Customer customer)
        //{
        //    string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
        //    SqlConnection sqlConnection = new SqlConnection(sqlString);

        //    string commandString = @"UPDATE Customers SET Code = '" + customer.Code + "', Name = '" + customer.Name + "', Contact = '" + customer.Contact + "', Address = '" + customer.Address + "', DistrictId = " + customer.DistrictId + " WHERE ID = " + customer.ID + " ";
        //    SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

        //    sqlConnection.Open();

        //    int isUpdated = sqlCommand.ExecuteNonQuery();

        //    sqlConnection.Close();

        //    if (isUpdated > 0)
        //        return true;
        //    else
        //        return false;
        //}

        //public List<District> ComboDistricts()
        //{
        //    List<District> districts = new List<District>();

        //    string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
        //    SqlConnection sqlConnection = new SqlConnection(sqlString);

        //    string commandString = @"SELECT ID, Name FROM Districts";
        //    SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

        //    sqlConnection.Open();

        //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        //    while (sqlDataReader.Read())
        //    {
        //        District district = new District();

        //        district.ID = Convert.ToInt32(sqlDataReader["ID"]);
        //        district.Name = sqlDataReader["Name"].ToString();

        //        districts.Add(district);
        //    }

        //    sqlConnection.Close();

        //    District dis = new District();
        //    dis.ID = 0;
        //    dis.Name = "-SELECT-";
        //    districts.Insert(0, dis);

        //    return districts;
        //}

        public List<Customers> Display()
        {
            List<Customers> viewCustomers = new List<Customers>();

            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                

                Customers viewCustomer = new Customers();

                viewCustomer.ID = Convert.ToInt32(sqlDataReader["ID"]);
                viewCustomer.Code = sqlDataReader["Code"].ToString();
                viewCustomer.Name = sqlDataReader["Name"].ToString();               
                viewCustomer.Address = sqlDataReader["Address"].ToString();
                viewCustomer.Email = sqlDataReader["Email"].ToString();
                viewCustomer.Contact = sqlDataReader["Contact"].ToString();
                viewCustomer.LoyaltyP = Convert.ToInt32(sqlDataReader["LoyaltyP"]); 

                viewCustomers.Add(viewCustomer);
            }

            sqlConnection.Close();

            return viewCustomers;
        }

        public bool IsCodeUniqe(string code)
        {
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Customers WHERE Code = '" + code + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            int flag = 0;
            while (sqlDataReader.Read())
            {
                flag = 1;
                break;
            }

            sqlConnection.Close();

            if (flag == 0)
                return true;
            else
                return false;
        }

        public bool IsContactUniqe(string contact)
        {
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Customers WHERE Contact = '" + contact + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            int flag = 0;
            while (sqlDataReader.Read())
            {
                flag = 1;
                break;
            }

            sqlConnection.Close();

            if (flag == 0)
                return true;
            else
                return false;
        }

        //public double GetLoyaltiPointById(Customers customer)
        //{
        //    double point = 0;
        //    string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
        //    SqlConnection sqlConnection = new SqlConnection(sqlString);

        //    string commandString = @"SELECT LoyaltyP FROM Customers WHERE Code = '" + customer.Code + "'";
        //    SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

        //    sqlConnection.Open();

        //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

          
        //    while (sqlDataReader.Read())
        //    {
        //        point = Convert.ToDouble(sqlDataReader["LoyaltyP"]);
               
        //    }

        //    sqlConnection.Close();

           
        //        return point;
        //}



        //public List<Customer> SearchCustomerByCode(Customer cus)
        //{
        //    List<Customer> customers = new List<Customer>();

        //    string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
        //    SqlConnection sqlConnection = new SqlConnection(sqlString);

        //    string commandString = @"SELECT * FROM Customers WHERE Code = '" + cus.Code + "'";
        //    SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

        //    sqlConnection.Open();

        //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        //    while (sqlDataReader.Read())
        //    {
        //        Customer customer = new Customer();

        //        customer.ID = Convert.ToInt32(sqlDataReader["ID"]);
        //        customer.Code = sqlDataReader["Code"].ToString();
        //        customer.Name = sqlDataReader["Name"].ToString();
        //        customer.Contact = sqlDataReader["Contact"].ToString();
        //        customer.Address = sqlDataReader["Address"].ToString();
        //        customer.DistrictId = Convert.ToInt32(sqlDataReader["DistrictId"]);

        //        customers.Add(customer);
        //    }

        //    sqlConnection.Close();

        //    return customers;
        //}
    }
}
