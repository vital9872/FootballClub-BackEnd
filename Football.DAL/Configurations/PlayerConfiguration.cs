using System;
using System.Collections.Generic;
using System.Text;
using Football.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.DAL.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired();

            builder.Property(e => e.Birth)
                .HasColumnType("datetime2");

            builder.Property(e => e.Position)
                .HasMaxLength(3)
                .HasConversion(x => x.ToString(),
                    x => (Position)Enum.Parse(typeof(Position), x))
                .HasDefaultValue(Position.CM);


            builder.HasOne(e => e.Contract)
                .WithOne()
                .HasForeignKey<Player>(e => e.ContractId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
