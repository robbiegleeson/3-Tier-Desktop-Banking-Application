using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridsAndColumns
{
    //Enum for referencing DataGridColumns of the DataGrid for Transactions
    public enum TransactionGrid
    {
        AccountNumber = 0,
        TransactionID,
        Type,
        Date,
        Amount,
        Description
    }
}
