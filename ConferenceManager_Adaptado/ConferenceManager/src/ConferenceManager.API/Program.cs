
using ConferenceManager.Application.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/conference/schedule", (List<string> palestrasInput) =>
{
    var parser = new PalestraParser();

    var palestras = parser.Parse(palestrasInput);

    var scheduler = new ConferenceSchedulerService();

    var trilhas = scheduler.Organizar(palestras);

    var formatter = new AgendaFormatter();

    var agenda = formatter.Exibir(trilhas);

    return Results.Ok(agenda);
});

app.Run();
