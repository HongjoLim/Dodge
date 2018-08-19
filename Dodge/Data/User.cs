using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;

namespace Dodge.Data
{
    /// <summary>
    /// 
    /// Name:       Jo Lim
    /// Date:         Aug 13 2018
    /// Purpose:    This class stores a user's information
    /// 
    /// </summary>

    public class User
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
