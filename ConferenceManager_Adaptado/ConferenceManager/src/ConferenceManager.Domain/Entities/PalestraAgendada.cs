
namespace ConferenceManager.Domain.Entities;

public class PalestraAgendada
{
    public Palestra Palestra { get; private set; }
    public TimeSpan Inicio { get; private set; }

    public PalestraAgendada(Palestra palestra, TimeSpan inicio)
    {
        Palestra = palestra;
        Inicio = inicio;
    }
}
