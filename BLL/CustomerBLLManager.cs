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
        //returns an instance of a customer
        public Customer GetCustomerDetails(int customerID)
        {
            return customerDAL.GetCustomerDetails(customerID);
        }
        //returns (un)successful update of customer info
        public bool UpdateCustomer(Customer updateCustomer)
        {
            return customerDAL.UpdateCustomer(updateCustomer);
        }
    }
}
