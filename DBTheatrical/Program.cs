
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Configuração Swagger no builder
//http://localhost:porta/swagger/index.html
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura a serialização do JSON para evitar referência circular
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(
  options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

builder.Services.AddDbContext<TheatricalPlayersRefactoringKataContext>();

builder.Services.AddCors();

var app = builder.Build();

//Configuração Swagger no app
app.UseSwagger();
app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "TheatricalPlayers");
    });

//APIs
app.MapGet("/", () => "APIs relacionadas com EF + Swagger");
app.MapPerformanceApi();
app.MapPlayApi();
app.MapInvoiceApi();


app.UseCors(opcoes => opcoes.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();


