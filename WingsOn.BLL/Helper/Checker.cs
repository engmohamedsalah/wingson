using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace WingsOn.BLL.Helper
{
    /// <summary>
    /// this is check helper class
    /// </summary>
    public class Checker
    {
        /// <summary>
        /// Determines whether [is valid email] [the specified email].
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        ///   <c>true</c> if [is valid email] [the specified email]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidEmail(string email)
        {
            //check if the email string is null or empty
            if (string.IsNullOrEmpty(email))
                return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
