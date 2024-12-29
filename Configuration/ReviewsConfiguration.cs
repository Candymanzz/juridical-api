using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class ReviewsConfiguration : IEntityTypeConfiguration<ReviewsEntities>
    {
        public void Configure(EntityTypeBuilder<ReviewsEntities> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Client).WithOne(cl => cl.Review);
            builder.HasOne(r => r.Lawyer).WithOne(l => l.Review);

            builder.HasData
            (
                new ReviewsEntities
                {
                    Id = new Guid("8B9658B8-49C1-423A-A807-71D1706710E8"),
                    Rating = 4,
                    Comment = "Normale",
                    Date = new DateTime(2004, 9, 19),
                    ClientId = new Guid("8B9658B8-49C1-423A-A807-71D1706710E1"),
                    LawyerId = new Guid("8B9658B8-49C1-423A-A807-71D1706710E2")
                }
            );
        }
    }
}