using System;
using System.Collections.Generic;
using System.Text;
using Football.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.DAL.Configurations
{
    class PlayerContractConfiguration: IEntityTypeConfiguration<PlayerContract>
    {

        public void Configure(EntityTypeBuilder<PlayerContract> builder)
        {
            builder.Property(e => e.ExpireDate)
                .HasColumnType("datetime2");

            builder.Property(e => e.SignedDate)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
