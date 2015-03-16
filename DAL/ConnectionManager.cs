using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace DAL
{
    public abstract class ConnectionManager
    {
        string connsectionString = ConfigurationManager.ConnectionStrings["DBSCU"].ConnectionString;

        public string ConnectionString
        {
            get
            {
                return connsectionString;
            }
            set
            {
                connsectionString = value;
            }
        }


    }
}
