using MySql.Data.MySqlClient;

class Database
{
    // conexão com o mysql
    public static MySqlConnection Conexao()
    {
        // variaveis de ambiente
        string host = Environment.GetEnvironmentVariable("DB_HOST");
        string port = Environment.GetEnvironmentVariable("PORT");
        string db = Environment.GetEnvironmentVariable("DB_NAME");
        string user = Environment.GetEnvironmentVariable("DB_USER");
        string pass = Environment.GetEnvironmentVariable("DB_PASSWORD");

        string stringconexao =
            $"Server={host};Port={port};Database={db};User={user};Password={pass};";

        return new MySqlConnection(stringconexao);
    }
}
