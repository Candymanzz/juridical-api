using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class CourtHearingsConfiguration : IEntityTypeConfiguration<CourtHearingsEntities>
    {
        public void Configure(EntityTypeBuilder<CourtHearingsEntities> builder)
        {
            builder.HasKey(ch => ch.Id);

            builder.HasOne(ch => ch.Case).WithOne(cs => cs.CourtHearing);

            builder.HasData
            (
                new CourtHearingsEntities
                {
                    Id = new Guid("8B9658B8-49C1-423A-A807-71D1706710E4"),
                    HearingDate = new DateTime(2001, 11, 02),
                    Place = "Belovejskay pyshcha",
                    CaseId = new Guid("8B9658B8-49C1-423A-A807-71D1706710E5")
                }
            );
        }
    }
}