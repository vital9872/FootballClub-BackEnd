using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestDbFirst
{
    public partial class FootballClubKPZContext : DbContext
    {
        public FootballClubKPZContext()
        {
        }

        public FootballClubKPZContext(DbContextOptions<FootballClubKPZContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerMatch> PlayerMatches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FootballClubKPZ;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Budget).HasColumnName("budget");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.YearFounded).HasColumnName("year_founded");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.SignedDate).HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasIndex(e => e.ClubId, "IX_Matches_Club_Id");

                entity.Property(e => e.ClubEnemyName)
                    .HasMaxLength(50)
                    .HasColumnName("Club_Enemy_Name");

                entity.Property(e => e.ClubId).HasColumnName("Club_Id");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.Team1Goals).HasColumnName("Team1_Goals");

                entity.Property(e => e.Team2Goals).HasColumnName("Team2_Goals");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.HasIndex(e => e.ClubId, "IX_Player_Club_Id");

                entity.HasIndex(e => e.ContractId, "IX_Player_Contract_Id")
                    .IsUnique()
                    .HasFilter("([Contract_Id] IS NOT NULL)");

                entity.Property(e => e.ClubId).HasColumnName("Club_Id");

                entity.Property(e => e.ContractId).HasColumnName("Contract_Id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasDefaultValueSql("(N'CM')");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Contract)
                    .WithOne(p => p.Player)
                    .HasForeignKey<Player>(d => d.ContractId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PlayerMatch>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.MatchId });

                entity.HasIndex(e => e.MatchId, "IX_PlayerMatches_Match_Id");

                entity.Property(e => e.PlayerId).HasColumnName("Player_Id");

                entity.Property(e => e.MatchId).HasColumnName("Match_Id");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.PlayerMatches)
                    .HasForeignKey(d => d.MatchId);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerMatches)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
