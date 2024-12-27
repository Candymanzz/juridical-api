using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class CasesConfiguration : IEntityTypeConfiguration<CasesEntities>
    {
        public void Configure(EntityTypeBuilder<CasesEntities> builder)
        {
            builder.HasData
            (
                new CasesEntities
                {
                    Id = 1,
                    CaseName = "Case name 1",
                    Description = "Some description",
                    OpeningDate = new DateTime(2000, 11, 220),
                    ClientId = 1,
                    LawyerId = 1
                }
            );
        }
    }
}