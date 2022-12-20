using Microsoft.Data.SqlClient;
using Model;

namespace Controller;

public static class Database
{
    #region Properties

    private static readonly SqlConnectionStringBuilder Builder = new()
    {
        // TODO: security for this shit
        DataSource = @"127.0.0.1",
        UserID = "sa",
        Password = "Betaverse01!",
        InitialCatalog = "zuypr",
        TrustServerCertificate= true,
    };
    private static readonly SqlConnection Connection = new(Builder.ConnectionString);

    #endregion

    #region User

    public static User UserGet(int id)
    {
        User user = null;
        string query = $"SELECT * FROM users WHERE id = {id}";

        using SqlCommand command = new(query, Connection);
        
        Connection.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                user ??= new User(reader.GetString(1), reader.GetString(2), reader.GetString(4),
                    reader.GetDateTime(3), reader.GetInt32(0));
            }
        }
        Connection.Close();

        return user;
    }

    #endregion
}