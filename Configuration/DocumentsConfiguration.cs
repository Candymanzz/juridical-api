using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class DocumentsConfiguration : IEntityTypeConfiguration<DocumentsEntities>
    {
        public void Configure(EntityTypeBuilder<DocumentsEntities> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.Case).WithOne(cs => cs.Document);

            builder.HasData
            (
                new DocumentsEntities
                {
                    Id = new Guid("8B9658B8-49C1-423A-A807-71D1706710E6"),
                    DocumentName = "Super Document",
                    CreationDate = new DateTime(2005, 5, 14),
                    DocumentType = "Dicloration",
                    CaseId = new Guid("8B9658B8-49C1-423A-A807-71D1706710E5")
                }
            );
        }
    }
}