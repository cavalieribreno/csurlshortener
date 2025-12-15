using DotNetEnv;
using Org.BouncyCastle.Asn1.Ocsp;
Env.Load();
var builder = WebApplication.CreateBuilder(args);
var program = builder.Build();
// post fazendo a inserção no banco de dados 
program.MapPost("/short", async (HttpContext context) =>
{
    // lê o json do body e converte para dictionary
    var body = await context.Request.ReadFromJsonAsync<Dictionary<string, string>>();
    if(body == null)
    {
        return Results.BadRequest("Operação inválida");
    }
    // url vinda no json
    string UrlOriginal = body["original_url"];

    string ShortUrl = GeradorCodigo.Gerarcode();

    string ShortUrlCreated = UrlRepository.CreateUrl(UrlOriginal, ShortUrl);

    return Results.Ok(ShortUrlCreated);
});
// get para pegar a url original e redirecionar
program.MapGet("/{ShortUrl}", async (string ShortUrl) =>
{
    string UrlOriginal = UrlRepository.GetOriginalUrl(ShortUrl);
    if (UrlOriginal == null)
    {
        return Results.NotFound("Não foi possivel encontrar");
    }
    Console.WriteLine($"Redirecionando para: {UrlOriginal}");
    return Results.Redirect(UrlOriginal);
});

program.Run();
