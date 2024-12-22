using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class CourtHearingsConfiguration : IEntityTypeConfiguration<CourtHearingsEntities>
    {
        public void Configure(EntityTypeBuilder<CourtHearingsEntities> builder)
        {
            builder.HasData
            (
                new CourtHearingsEntities
                {
                    Id = 1,
                    HearingDate = new DateTime(2001, 11, 02),
                    Place = "Belovejskay pyshcha",
                    CaseId = 1
                }
            );
        }
    }
}