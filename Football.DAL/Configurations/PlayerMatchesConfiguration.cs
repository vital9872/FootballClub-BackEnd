using System;
using System.Collections.Generic;
using System.Text;
using Football.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.DAL.Configurations
{
    public class PlayerMatchesConfiguration: IEntityTypeConfiguration<PlayerMatch>
    {
        public void Configure(EntityTypeBuilder<PlayerMatch> builder)
        {
            builder
                .HasKey(e => new { e.PlayerId, e.MatchId });

            builder
                .HasOne(e => e.Player)
                .WithMany(p => p.PlayerMatches)
                .HasForeignKey(e => e.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Match)
                .WithMany(m => m.PlayerMatches)
                .HasForeignKey(e => e.MatchId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
