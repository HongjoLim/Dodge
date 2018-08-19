using Dodge.Data;
using System.Linq;

namespace Dodge.Util
{   
     /// <summary>
     /// 
     /// Name:       Jo Lim
     /// Date:         Aug 18 2018
     /// Purpose:    This class validates signining in user's input
     /// 
     /// </summary>
    static class UserSignInTool
    {
        public static bool SignIn(User user)
        {
            using (var userDbContext = new UserDbContext())
            {
                // Find the matching user's data and store it in a variable using LINQ
                var data = userDbContext.Users.Where(x => x.UserName == user.UserName&&x.Password==user.Password);

                // If the number of returned data is less than 1, return false
                if (data.Count() < 1)
                {
                    return false;
                }
                // If the matching data has been found, return true;
                else
                {
                    return true;
                }
            }
        }
    }
}
