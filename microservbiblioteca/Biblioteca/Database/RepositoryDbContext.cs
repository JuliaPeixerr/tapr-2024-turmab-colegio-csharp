using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Azure.Cosmos;
using microservbiblioteca.Biblioteca.Entities;

namespace microservbiblioteca.Biblioteca.Database
{
    public class RepositoryDbContext : DbContext
    {
        private IConfiguration _configuration;

        public RepositoryDbContext(IConfiguration configuration)
            => _configuration = configuration;

        public DbSet<Livro> Livro { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<AlunoLivro> AlunoLivro { get; set; }
        public DbSet<LivroStatus> LivroStatus { get; set; }
        public DbSet<LivroTema> LivroTema { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                connectionString: _configuration["CosmosDBURL"],
                databaseName: _configuration["CosmosDBDBName"],
                cosmosOptionsAction: options =>
                {
                    options.ConnectionMode(ConnectionMode.Gateway);
                    options.HttpClientFactory(() => new HttpClient(new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    }));
                }
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>()
                .ToContainer("livro")
                .HasPartitionKey(p => p.Id)
                .HasAutoscaleThroughput(400)
                .HasNoDiscriminator()
                .Property(p => p.Id)
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired(true);

            modelBuilder.Entity<Aluno>()
               .ToContainer("aluno")
               .HasPartitionKey(p => p.Id)
               .HasAutoscaleThroughput(400)
               .HasNoDiscriminator()
               .Property(p => p.Id)
               .HasValueGenerator<GuidValueGenerator>()
               .IsRequired(true);

            modelBuilder.Entity<AlunoLivro>()
               .ToContainer("alunoLivro")
               .HasPartitionKey(p => p.Id)
               .HasAutoscaleThroughput(400)
               .HasNoDiscriminator()
               .Property(p => p.Id)
               .HasValueGenerator<GuidValueGenerator>()
               .IsRequired(true);

            modelBuilder.Entity<LivroStatus>()
               .ToContainer("livroStatus")
               .HasPartitionKey(p => p.Id)
               .HasAutoscaleThroughput(400)
               .HasNoDiscriminator()
               .Property(p => p.Id)
               .HasValueGenerator<GuidValueGenerator>()
               .IsRequired(true);

            modelBuilder.Entity<LivroTema>()
               .ToContainer("livroTema")
               .HasPartitionKey(p => p.Id)
               .HasAutoscaleThroughput(400)
               .HasNoDiscriminator()
               .Property(p => p.Id)
               .HasValueGenerator<GuidValueGenerator>()
               .IsRequired(true);
        }
    }
}
