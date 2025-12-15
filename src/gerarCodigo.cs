using System;
using System.Text;
class GeradorCodigo
{
    // gera um código com 6 caracteres aleatórios
    public static string Gerarcode()
    {
        return Guid.NewGuid().ToString("N").Substring(0, 6);
    }
}