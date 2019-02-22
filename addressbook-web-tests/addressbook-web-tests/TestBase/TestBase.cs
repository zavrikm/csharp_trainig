using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {

        protected ApplicationManager app; //field for link to Application Manager instance



        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        #region Common Methods

        public static string GenerateRandomString(int max) //генератор случайных строк
        {

            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < l; i++)
            {
               builder.Append(Convert.ToChar(Convert.ToInt32(rnd.NextDouble()*223 + 32)));
            }
            return builder.ToString();
        }

        public static int GetMonthNumber(string month)
        {
            if (month == "-") { return 0; };
            if (month == "January") { return 1; };
            if (month == "February") { return 2; };
            if (month == "March") { return 3; };
            if (month == "April") { return 4; };
            if (month == "May") { return 5; };
            if (month == "June") { return 6; };
            if (month == "July") { return 7; };
            if (month == "August") { return 8; };
            if (month == "September") { return 9; };
            if (month == "October") { return 10; };
            if (month == "November") { return 11; };
            return 12;
        }

        #endregion

        #region Random Contact Data generation

        public static string GenerateRandomPhone()
        {
            return rnd.Next(1000000,9999999).ToString();
        }

        public static string GenerateRandomEmail()
        {
            return GenerateRandomString(64) + "@" + GenerateRandomString(249) + "." + GenerateRandomString(5);
        }

        public static string GenerateRandomeHomePage()
        {
            return GenerateRandomString(249) + "." + GenerateRandomString(5);
        }

        public static string GenerateRandomYear()
        {
            return rnd.Next(1900,2100).ToString();
        }

        public static string GenerateRandomMonth()
        {
            int month = rnd.Next(0, 12);

            if (month == 0) { return "-"; };
            if (month == 1) { return "January"; };
            if (month == 2) { return "February"; };
            if (month == 3) { return "March"; };
            if (month == 4) { return "April"; };
            if (month == 5) { return "May"; };
            if (month == 6) { return "June"; };
            if (month == 7) { return "July"; };
            if (month == 8) { return "August"; };
            if (month == 9) { return "September"; };
            if (month == 10) { return "October"; };
            if (month == 11) { return "November"; };

            return "December";

        }

        public static string GenerateRandomDay(int month, string year)
        {
            string day = "";
            

            if (month == 2)
            {
                if (Int32.Parse(year) % 4 == 0) // високосный год
                {
                    day = rnd.Next(0, 29).ToString();
                }
                else
                {
                    day = rnd.Next(0, 28).ToString();
                }
            }

            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                day = rnd.Next(0, 31).ToString();
            }

            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                day = rnd.Next(0, 30).ToString();
            }

            if (day == "0") { return "-"; };

            return day;
        }

        public static string GenerateContactTitle()
        {
            int number = rnd.Next(0, 2);

            if (number == 0) { return "Mr"; };
            if (number == 1) { return "Ms"; };
            return "Mrs";
        }


        #endregion

    }
}
