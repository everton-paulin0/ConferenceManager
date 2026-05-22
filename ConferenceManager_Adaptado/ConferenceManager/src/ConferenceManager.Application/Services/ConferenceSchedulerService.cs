
using ConferenceManager.Domain.Entities;

namespace ConferenceManager.Application.Services;

public class ConferenceSchedulerService
{
    public List<Trilha> Organizar(List<Palestra> palestras)
    {
        var trilhas = new List<Trilha>();

        var ordenadas = palestras
            .OrderByDescending(x => x.Duracao)
            .ToList();

        while (ordenadas.Any())
        {
            var trilha = new Trilha(trilhas.Count + 1);

            PreencherSessao(trilha.Manha, ordenadas);
            PreencherSessao(trilha.Tarde, ordenadas);

            trilhas.Add(trilha);
        }

        return trilhas;
    }

    private void PreencherSessao(
        Sessao sessao,
        List<Palestra> palestras)
    {
        var horarioAtual = sessao.Inicio;

        var copia = palestras.ToList();

        foreach (var palestra in copia)
        {
            if (!sessao.PodeAdicionar(palestra))
                continue;

            sessao.Palestras.Add(
                new PalestraAgendada(
                    palestra,
                    horarioAtual));

            horarioAtual = horarioAtual
                .Add(TimeSpan.FromMinutes(palestra.Duracao));

            palestras.Remove(palestra);
        }
    }
}
