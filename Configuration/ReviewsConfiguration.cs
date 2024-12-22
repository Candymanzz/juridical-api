using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class ReviewsConfiguration : IEntityTypeConfiguration<ReviewsEntities>
    {
        public void Configure(EntityTypeBuilder<ReviewsEntities> builder)
        {
            builder.HasData
            (
                new ReviewsEntities
                {
                    Id = 1,
                    Rating = 4,
                    Comment = "Normale",
                    Date = new DateTime(2004, 9, 19),
                    ClientId = 1,
                    LawyerId = 1
                }
            );
        }
    }
}