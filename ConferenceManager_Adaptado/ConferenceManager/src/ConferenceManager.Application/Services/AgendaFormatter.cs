
using ConferenceManager.Domain.Entities;

namespace ConferenceManager.Application.Services;

public class AgendaFormatter
{
    public string Exibir(List<Trilha> trilhas)
    {
        var output = new List<string>();

        foreach (var trilha in trilhas)
        {
            output.Add($"Trilha {trilha.Numero}");

            ImprimirSessao(trilha.Manha, output);

            output.Add("12:00 Almoço");

            ImprimirSessao(trilha.Tarde, output);

            var ultima = trilha.Tarde.Palestras.Last();

            var networking = ultima.Inicio
                .Add(TimeSpan.FromMinutes(
                    ultima.Palestra.Duracao));

            if (networking < TimeSpan.FromHours(16))
                networking = TimeSpan.FromHours(16);

            output.Add($"{networking:hh\\:mm} Networking Event");
            output.Add("");
        }

        return string.Join(Environment.NewLine, output);
    }

    private void ImprimirSessao(
        Sessao sessao,
        List<string> output)
    {
        foreach (var item in sessao.Palestras)
        {
            output.Add(
                $"{item.Inicio:hh\\:mm} " +
                $"{item.Palestra.Titulo} " +
                $"{item.Palestra.Duracao}min");
        }
    }
}
