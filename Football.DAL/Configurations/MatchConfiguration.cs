using System;
using System.Collections.Generic;
using System.Text;
using Football.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.DAL.Configurations
{
    public class MatchConfiguration:IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.Property(e => e.StartDate)
                .HasColumnType("datetime2");

            builder.Property(e => e.ClubEnemyName)
                .HasMaxLength(50);
        }

    }
}
