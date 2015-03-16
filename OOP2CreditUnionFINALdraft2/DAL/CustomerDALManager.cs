using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataModels;

namespace DAL
{
    public class CustomerDALManager : ConnectionManager
    {
        SqlConnection cxn;
        SqlCommand cmd;

        public Customer GetCustomerDetails(int customerID)
        {
            Customer currentCustomer = null;
            try
            {
                using (cxn = new SqlConnection(this.ConnectionString))
                {
                    using (cmd = new SqlCommand("spGetCustomerInformation", cxn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
                        cxn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();

                        currentCustomer = new Customer();
                        currentCustomer.CustomerID = customerID;

                        while (dataReader.Read())
                        {
                            currentCustomer.FirstName = dataReader["Firstname"].ToString();
                            currentCustomer.Surname = dataReader["Surname"].ToString();
                            currentCustomer.Email = dataReader["Email"].ToString();
                            currentCustomer.Phone = dataReader["Phone"].ToString();
                            currentCustomer.AddressLine1 = dataReader["AddressLine1"].ToString();
                            currentCustomer.AddressLine2 = dataReader["AddressLine2"].ToString();
                            currentCustomer.City = dataReader["City"].ToString();
                            currentCustomer.County = dataReader["County"].ToString();
                        }
                        dataReader.Close();
                        cxn.Close();
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return currentCustomer;
            
        }

        public bool UpdateCustomer(Customer updateCustomer)
        {
            bool customerUpdated = false;
            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spUpdateCustomer"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = updateCustomer.FirstName;
                    cmd.Parameters.Add("@Surname", SqlDbType.NVarChar, 50).Value = updateCustomer.Surname;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = updateCustomer.Email;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 50).Value = updateCustomer.Phone;
                    cmd.Parameters.Add("@AddressLine1", SqlDbType.NVarChar, 50).Value = updateCustomer.AddressLine1;
                    cmd.Parameters.Add("@AddressLine2", SqlDbType.NVarChar, 50).Value = updateCustomer.AddressLine2;
                    cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = updateCustomer.City;
                    cmd.Parameters.Add("@County", SqlDbType.NVarChar, 50).Value = updateCustomer.County;
                    cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = updateCustomer.CustomerID;

                    cxn.Open();
                    cmd.Connection = cxn;
                    cmd.ExecuteNonQuery();
                    cxn.Close();
                    customerUpdated = true;
                }
                if (customerUpdated)
                {
                    return true;
                }
                else
                    return false;

            }
        }
    }
}
