using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Student_Analyser
{
    public class SQLDataAccess
    {
        private static SqlConnectionStringBuilder builder = Connection.ConnectionStringBuilder();
        public static SqlDataReader reader;
        public async static Task<List<User_Account>> GetUsersAsync()
        {
            List<User_Account> users = new List<User_Account>();
            try
            { 
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT TOP (1000) * FROM [dbo].[User]");
                    string sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User_Account(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5) , reader.GetString(6)));
                            }
                        }
                        if(connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw e.InnerException;
            }
            
            return users;
        }

        public async static Task InsertUserAsync( User_Account user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append(@"INSERT INTO [dbo].[User] VALUES (" + user.Id + ",'" + user.Email_address + "','" + user.Username + "','" + user.Password + "','" + user.SecurityQuestion + "','" + user.Answer + "','" + user.StudentNo + "')");

                    string sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (SqlException e)
            {
                throw e.InnerException;
            }
        }
        public async  static Task UpdateSecurityAsync(User_Account user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append(@"UPDATE [dbo].[User] SET  Securityquestion ='" + user.SecurityQuestion + "',' Answer" + user.Answer + "' WHERE Email = '"+user.Email_address);

                    string sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (SqlException e)
            {
                throw e.InnerException;
            }
        }

        public async static Task ResetPassword(string newPassword, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(@"UPDATE [dbo].[User] SET  password ='" + newPassword+ " WHERE Email = '" + email);

                    string sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (SqlException e)
            {
                throw e.InnerException;
            }
        }
    }
}
