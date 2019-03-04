using System;
using System.Text.RegularExpressions;

namespace XamarinAssignment.Helpers
{
    public class Utils
    {
        public static bool IsValidEmail(string Email)
        {
            bool isEmail = Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }

        public static bool IsValidUrl(string WebUrl)
        {
            return Regex.IsMatch(WebUrl, @"([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }

        //private bool Is_Valid_Url(string WebUrl)
        //{
        //    return Regex.IsMatch(url, @"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        //}

        public static string GetCurrentDate()
        {
            var ToDaydate = DateTime.UtcNow;
            string date = ToDaydate.Day + "/" + ToDaydate.Month + "/" + ToDaydate.Year;
            return date;
        }

    }
}
