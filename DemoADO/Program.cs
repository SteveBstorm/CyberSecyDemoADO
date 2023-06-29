using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

string connectionString = @"Data Source=STEVEBSTORM\MSSQLSERVER01;Initial Catalog=CyberSecuDemoADO;Integrated Security=True;";

#region reste fermer !!!
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    #region Commentaire
//    //connection.ConnectionString = connectionString;
//    //Console.WriteLine(connection.State);
//    //connection.Open();
//    //Console.WriteLine(connection.State);
//    //connection.Close();
//    //Console.WriteLine(connection.State); 
//    #endregion

//    using(SqlCommand command = new SqlCommand())
//    {
//        command.Connection = connection;

//        string sql = "SELECT COUNT(*) FROM Contact";
//        command.CommandText = sql;

//        connection.Open();
//        int resultat = (int)command.ExecuteScalar();
//        connection.Close();
//        Console.WriteLine(resultat);
//    }

//    using (SqlCommand command = connection.CreateCommand())
//    {
//        string sql = "SELECT * FROM Contact";
//        command.CommandText= sql;
//        connection.Open();

//        using (SqlDataReader reader = command.ExecuteReader())
//        {
//            while (reader.Read())
//            {
//                Console.WriteLine(reader["email"]);
//            }
//        }
//    }
//}

//command.ExecuteReader(); //SELECT avec Résultat Multi valeur
//command.ExecuteScalar(); //SELECT Résultat à valeur UNIQUE 
//command.ExecuteNonQuery(); //Pas de résultat (INSERT/UPDATE/DELETE)

#endregion

using(SqlConnection conn = new SqlConnection(connectionString))
{
    using(SqlCommand cmd = conn.CreateCommand())
    {
        string email = "'or 1 = 1; --monadresse@truc.com";
        string sql = "INSERT INTO Contact (Firstname, Lastname, email)" +
            " OUTPUT inserted.Id" +
            " VALUES( @first, @last, @email)";

        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("email", email);
        cmd.Parameters.AddWithValue("first", "Perceval");
        cmd.Parameters.AddWithValue("last", "De Galles");

        SqlParameter param1 = new SqlParameter();
        param1.ParameterName = "Id";
        param1.Value = 0;
        

        conn.Open();
        int newId = (int)cmd.ExecuteScalar();
        //int affectedRows = cmd.ExecuteNonQuery();
        Console.WriteLine("Nouvel Id = " +newId);
        conn.Close();
    }
}




string s = "5";

int x;

bool test = int.TryParse(s, out x);