using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {

        protected ApplicationManager app; //field for link to Application Manager class



        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();

        }




    }
}
