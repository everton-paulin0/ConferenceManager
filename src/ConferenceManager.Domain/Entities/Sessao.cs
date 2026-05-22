using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceManager.Domain.Entities
{
    public class Sessao
    {
        public TimeSpan Inicio { get; private set; }

        public TimeSpan Fim { get; private set; }

        public List<PalestraAgendada> Palestras{ get; private set; }

        public Sessao(TimeSpan inicio, TimeSpan fim)
        {
            Inicio = inicio;
            Fim = fim;

            Palestras = new List<PalestraAgendada>();
        }

        public int DuracaoTotal()
        {
            return (int)(Fim - Inicio).TotalMinutes;
        }

        public int MinutosUtilizados()
        {
            return Palestras.Sum(x => x.Palestra.Duracao);
        }

        public bool PodeAdicionar(Palestra palestra)
        {
            return MinutosUtilizados() + palestra.Duracao
                <= DuracaoTotal();
        }
    }
}
