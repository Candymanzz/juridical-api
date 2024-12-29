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
            builder.HasKey(cs => cs.Id);

            builder.HasOne(cs => cs.Client).WithOne(cl => cl.Case);
            builder.HasOne(cs => cs.Lawyer).WithOne(l => l.Case);

            builder.HasOne(cs => cs.Payment).
                WithOne(p => p.Case).
                HasForeignKey<PaymentsEntities>(p => p.CaseId);
            builder.HasOne(cs => cs.Task).
                WithOne(t => t.Case).
                HasForeignKey<TasksEntities>(t => t.CaseId);
            builder.HasOne(cs => cs.Document).
                WithOne(d => d.Case).
                HasForeignKey<DocumentsEntities>(d => d.CaseId);
            builder.HasOne(cs => cs.CourtHearing).
                WithOne(ch => ch.Case).
                HasForeignKey<CourtHearingsEntities>(ch => ch.CaseId);

            builder.HasData
            (
                new CasesEntities
                {
                    Id = new Guid("8B9658B8-49C1-423A-A807-71D1706710E5"),
                    CaseName = "Case name 1",
                    Description = "Some description",
                    OpeningDate = new DateTime(2000, 11, 220),
                    ClientId = new Guid("8B9658B8-49C1-423A-A807-71D1706710E1"),
                    LawyerId = new Guid("8B9658B8-49C1-423A-A807-71D1706710E2")
                }
            );
        }
    }
}