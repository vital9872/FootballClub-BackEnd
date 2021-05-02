using System;
using System.Collections.Generic;
using System.Text;
using FCManagement_BackEnd.Models;
using Football.DAL.Configurations;
using Football.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Football.DAL.Context
{
    public class FootballContext: IdentityDbContext<User>
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerContract> Contracts { get; set; }
        public DbSet<PlayerMatch> PlayerMatches { get; set; }
        public DbSet<MatchBroadcast> MatchBroadcasts { get; set; }
        public DbSet<MatchTournament> MatchTournaments { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<PlayerTraining> PlayerTrainings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public FootballContext(DbContextOptions<FootballContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerMatchesConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerContractConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerTrainingConfiguration());
        }
    }
}
