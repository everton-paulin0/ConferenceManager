using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceManager.Domain.Entities
{
    public class Trilha { 
        public int Numero { get; private set; } 
        public Sessao Manha { get; private set; } 
        public Sessao Tarde { get; private set; } 
        public Trilha(int numero) { 
            Numero = numero; Manha = new Sessao( TimeSpan.FromHours(9), TimeSpan.FromHours(12)); 
            Tarde = new Sessao( TimeSpan.FromHours(13), TimeSpan.FromHours(17)); } 
    }
}
