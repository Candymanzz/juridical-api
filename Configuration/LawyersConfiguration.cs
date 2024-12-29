using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class LawyersConfiguration : IEntityTypeConfiguration<LawyersEntities>
    {
        public void Configure(EntityTypeBuilder<LawyersEntities> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.Case).
                WithOne(cs => cs.Lawyer).
                HasForeignKey<CasesEntities>(cs => cs.LawyerId);
            builder.HasOne(l => l.Review).
                WithOne(r => r.Lawyer).
                HasForeignKey<ReviewsEntities>(r => r.LawyerId);
            builder.HasOne(l => l.Task).
                WithOne(t => t.Lawyer).
                HasForeignKey<CasesEntities>(t => t.LawyerId);
            builder.HasOne(l => l.Contract).
                WithOne(cn => cn.Lawyer).
                HasForeignKey<CasesEntities>(cn => cn.LawyerId);

            builder.HasData
            (
                new LawyersEntities
                {
                    Id = new Guid("8B9658B8-49C1-423A-A807-71D1706710E2"),
                    FirstName = "Anna",
                    LastName = "Kanitta",
                    Specialization = "Criminal",
                    Phone = "+321333942073",
                    Email = "AnnaKanitta@gmail.com"
                }
            );
        }
    }
}