using microservbiblioteca.Biblioteca.Database;
using microservbiblioteca.Biblioteca.Services;
using microservbiblioteca.Biblioteca.Services.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryDbContext>();

//services
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IAlunoLivroService, AlunoLivroService>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ILivroTemaService, LivroTemaService>();
builder.Services.AddScoped<ILivroStatusService, LivroStatusService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
