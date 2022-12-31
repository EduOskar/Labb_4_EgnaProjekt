using Labb_4_EgnaProjekt.Data;
using Labb_4_EgnaProjekt.UserMenu;
using Microsoft.Data.SqlClient;

namespace Labb_4_EgnaProjekt
{
    internal class Program
    {
        public static List<LoginUsers> userList = new List<LoginUsers>();
        public static void Main(string[] args)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source = DESKTOP-8KGH2CT; Initial Catalog = AhlingsSchool;Integrated Security = True");
            AhlingsSchoolDbContext context = new AhlingsSchoolDbContext();

            AhlingSchool School = new AhlingSchool();
            AhlingSchool.Run();
        }
    }
}