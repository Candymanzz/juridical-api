using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class PaymentsConfiguration : IEntityTypeConfiguration<PaymentsEntities>
    {
        public void Configure(EntityTypeBuilder<PaymentsEntities> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Client).WithOne(cl => cl.Payment);
            builder.HasOne(p => p.Case).WithOne(cs => cs.Payment);

            builder.HasData
            (
                new PaymentsEntities
                {
                    Id = new Guid("8B9658B8-49C1-423A-A807-71D1706710E7"),
                    PaymentDate = new DateTime(2013, 1, 2),
                    Amount = 6000.32m,
                    PaymentMethod = "Card",
                    ClientId = new Guid ("8B9658B8-49C1-423A-A807-71D1706710E1"),
                    CaseId = new Guid("8B9658B8-49C1-423A-A807-71D1706710E5")
                }
            );
        }
    }
}