
using ConferenceManager.Domain.Entities;

namespace ConferenceManager.Application.Services;

public class PalestraParser
{
    public List<Palestra> Parse(List<string> linhas)
    {
        var palestras = new List<Palestra>();

        foreach (var linha in linhas)
        {
            var partes = linha.Split(' ');
            var ultimaParte = partes.Last();

            int duracao;

            if (ultimaParte.Contains("lightning"))
            {
                duracao = 5;
            }
            else
            {
                duracao = int.Parse(
                    ultimaParte.Replace("min", ""));
            }

            var titulo = linha.Replace(ultimaParte, "").Trim();

            palestras.Add(new Palestra(titulo, duracao));
        }

        return palestras;
    }
}
