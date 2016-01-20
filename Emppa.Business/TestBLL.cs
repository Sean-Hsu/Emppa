using Emppa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Business
{
    public class TestBLL
    {
        readonly TestDAL dalTest;

        public TestBLL()
        {
            this.dalTest = new TestDAL();
        }

        public void Select()
        {
            this.dalTest.Select();
        }
    }
}
