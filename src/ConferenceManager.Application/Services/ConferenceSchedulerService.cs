using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceManager.Domain.Entities;

namespace ConferenceManager.Application.Services
{
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
            while (true)
            {
                var restante = sessao.DuracaoTotal()
                    - sessao.MinutosUtilizados();

                var melhor = palestras
                    .Where(x => x.Duracao <= restante)
                .OrderByDescending(x => x.Duracao)
                .FirstOrDefault();

                if (melhor is null)
                    break;

                var horario = sessao.Inicio
                    .Add(TimeSpan.FromMinutes(
                        sessao.MinutosUtilizados()));

                sessao.Palestras.Add(
                    new PalestraAgendada(melhor, horario));

                palestras.Remove(melhor);
            }
        }
    }
}
