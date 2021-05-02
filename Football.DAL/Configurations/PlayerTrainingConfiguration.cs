using Football.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DAL.Configurations
{
    public class PlayerTrainingConfiguration : IEntityTypeConfiguration<PlayerTraining>
    {
        public void Configure(EntityTypeBuilder<PlayerTraining> builder)
        {
            builder
                .HasKey(e => new { e.PlayerId, e.TrainingId });

            builder
                .HasOne(e => e.Player)
                .WithMany(p => p.PlayerTrainings)
                .HasForeignKey(e => e.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Training)
                .WithMany(m => m.PlayerTrainings)
                .HasForeignKey(e => e.TrainingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
