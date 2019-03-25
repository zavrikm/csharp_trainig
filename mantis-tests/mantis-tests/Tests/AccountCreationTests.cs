using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace mantistests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [SetUp]

        public void SetUpConfig()
        {
            app.Ftp.BackUpFile("config/config_inc.php");
            using (Stream localfile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("config/config_inc.php", localfile);
            };
               

        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData() {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };
            app.Registration.Register(account);

        }

        [TearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackUpFile("config/config_inc.php");
        }

    }
}
