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
            builder.HasData
            (
                new PaymentsEntities
                {
                    Id = 1,
                    PaymentDate = new DateTime(2013, 1, 2),
                    Amount = 6000.32m,
                    PaymentMethod = "Card",
                    ClientId = 1,
                    CaseId = 1
                }
            );
        }
    }
}