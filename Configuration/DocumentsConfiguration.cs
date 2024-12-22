using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class DocumentsConfiguration : IEntityTypeConfiguration<DocumentsEntities>
    {
        public void Configure(EntityTypeBuilder<DocumentsEntities> builder)
        {
            builder.HasData
            (
                new DocumentsEntities
                {
                    Id = 1,
                    DocumentName = "Super Document",
                    CreationDate = new DateTime(2005, 5, 14),
                    DocumentType = "Dicloration",
                    CaseId = 1
                }
            );
        }
    }
}