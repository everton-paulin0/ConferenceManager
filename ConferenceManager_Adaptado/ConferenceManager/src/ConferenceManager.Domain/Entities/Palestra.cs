
namespace ConferenceManager.Domain.Entities;

public class Palestra
{
    public string Titulo { get; private set; }
    public int Duracao { get; private set; }

    public Palestra(string titulo, int duracao)
    {
        Titulo = titulo;
        Duracao = duracao;
    }
}
