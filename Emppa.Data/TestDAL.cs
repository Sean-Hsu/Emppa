using Emppa.Common.TestDomain.Table;
using Emppa.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Data
{
    public class TestDAL
    {
        readonly IDbHelper dbHelper;

        public TestDAL()
        {
            this.dbHelper = new DbHelper("Test");
        }

        public void Select()
        {
            string commandText = @"SELECT 
                    *
                FROM 
                    [dbo].[CUSTOMER]";

            IEnumerable<DtCustomer> Customers = this.dbHelper.ExecuteQuery<DtCustomer>(commandText);

            var c = Customers.ToList();

            string s = string.Empty;
        }
    }
}
