using Dodge.Data;

namespace Dodge.Util
{
    /// <summary>
    /// 
    /// Name:       Jo Lim
    /// Date:         Aug 18 2018
    /// Purpose:    This class registers user's data in the SQL Server using Data Entity Framework Core and DbSet<User>
    /// 
    /// </summary>

    static class UserRegisterTool
    {
        public static bool Register(User user) 
        {
            using (var userDbContext = new UserDbContext())
            {
                userDbContext.Users.Add(user);

                // Save changes to the database and store the return value in the variable 'result'
                var result = userDbContext.SaveChanges();

                // If the insertion has been failed, return false;
                if (result < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
