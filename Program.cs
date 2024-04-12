using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "server=127.0.0.1;Port=3306;uid=root;pwd=SENHA_DO_MYSQL_AQUI;database=DATABASE_AQUI;CharSet=utf8";

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SHOW TABLES;";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("Tabelas no banco de dados:");
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0)); // Aqui estamos acessando a primeira coluna (índice 0)
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há tabelas no banco de dados.");
                    }
                }

                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
    }
}


