using MySql.Data.MySqlClient;

class UrlRepository
{
    // método para criar dentro do banco de dados utilizando Using para liberação
    public static string CreateUrl(string UrlOriginal, string ShortUrl)
    {
        using (var conexao = Database.Conexao())
        {
            conexao.Open();

            string result = "INSERT INTO urls (original_url, short_url)" + "VALUES (@originalurl, @shorturl)";
            using (var comando = new MySqlCommand(result, conexao))
            {
                comando.Parameters.AddWithValue("@originalurl", UrlOriginal);
                comando.Parameters.AddWithValue("@shorturl", ShortUrl);
                comando.ExecuteNonQuery();
            }
        }
        return ShortUrl;
    }
    // método para pegar a url originaol do banco de dados.
    public static string? GetOriginalUrl(string ShortUrl)
    {
        using (var conexao = Database.Conexao())
        {
            conexao.Open();
            
            string result = "SELECT original_url FROM urls WHERE short_url = @shorturl";
            using (var comando = new MySqlCommand(result, conexao))
            {
                comando.Parameters.AddWithValue("@shorturl", ShortUrl);
                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return leitor.GetString("original_url");
                    }
                }
            }
        }
        return null;
    }
}
