﻿using DDD.Dominio.PicContext;
using DDD.Dominio.SecretariaContext;
using DDD.Dominio.UserContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {

        //https://balta.io/blog/ef-crud
        //https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversidadeDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Matricula>().HasKey(m => new { m.AlunoId, m.DisciplinaId });
            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Avaliacoes)
                .WithMany(e => e.Alunos);
            //.UsingEntity<Matricula>();


            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Avaliacao>().ToTable("Avaliação");

            //modelBuilder.Entity<Pesquisador>().ToTable("Pesquisador");
            //https://learn.microsoft.com/pt-br/ef/core/modeling/inheritance
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        //public DbSet<Avaliacao> Matriculas { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Pesquisador> Pesquisadores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
    }
}
