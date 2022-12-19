using Microsoft.Data.SqlClient;
using Model;

namespace Controller;

public static class Database
{
    #region Properties

    private const string ConnectionString = "Server=145.44.233.141;User ID=sa;Password=Betaverse01!;Initial Catalog=zuypr;";
    private static readonly SqlConnectionStringBuilder Builder = new()
    {
        // TODO: security for this shit
        DataSource = "145.44.233.141",
        UserID = "sa",
        Password = "Betaverse01!",
        InitialCatalog = "zuypr"
    };
    private static readonly SqlConnection Connection = new(ConnectionString);

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
                user ??= new User(reader.GetString(0), reader.GetString(2), reader.GetString(3),
                    reader.GetDateTime(4), reader.GetInt32(1));
            }
        }
        Connection.Close();

        return user;
    }

    #endregion
}