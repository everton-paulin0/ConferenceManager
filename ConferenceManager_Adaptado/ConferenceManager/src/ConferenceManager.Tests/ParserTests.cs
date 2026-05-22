
using ConferenceManager.Application.Services;
using FluentAssertions;

namespace ConferenceManager.Tests;

public class ParserTests
{
    [Fact]
    public void Deve_Converter_Lightning_Para_5_Minutos()
    {
        var parser = new PalestraParser();

        var result = parser.Parse(new List<string>
        {
            "Python lightning"
        });

        result.First().Duracao.Should().Be(5);
    }
}
