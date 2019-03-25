using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace mantistests
{
    public class TestBase
    {

        protected ApplicationManager app; //field for link to Application Manager instance



        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

       

    }
}
