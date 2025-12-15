using System;
using System.Text;

class GeradorCodigo
{
    public static string Gerarcode()
    {
        return Guid.NewGuid().ToString("N").Substring(0, 6);
    }
}