using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DAL;

namespace BLL
{
    public class CustomerBLLManager
    {
        CustomerDALManager customerDAL = new CustomerDALManager();

        public Customer GetCustomerDetails(int customerID)
        {
            return customerDAL.GetCustomerDetails(customerID);
        }
        public bool UpdateCustomer(Customer updateCustomer)
        {
            return customerDAL.UpdateCustomer(updateCustomer);
        }
    }
}
