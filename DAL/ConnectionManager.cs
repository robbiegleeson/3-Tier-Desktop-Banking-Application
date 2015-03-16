using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace DAL
{   //This class pulls connection string from the app.config and assigns it a public property
    //each class that inherits it can access it that
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
