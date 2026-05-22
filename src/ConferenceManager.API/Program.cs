using ConferenceManager.Application.Services;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); var app = builder.Build(); 

app.UseSwagger(); 
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConferenceManager API V1");
    
    c.RoutePrefix = string.Empty; }); 

app.MapGet("/", () => "Conference Manager API Online");

app.MapPost("/conference/schedule", (List<string> input) => { 

var parser = new PalestraParser(); 
var palestras = parser.Parse(input); 
var scheduler = new ConferenceSchedulerService(); 
var trilhas = scheduler.Organizar(palestras); 
var formatter = new AgendaFormatter(); 
var resultado = formatter.Exibir(trilhas);

return Results.Ok(resultado);

}); 

app.Run();