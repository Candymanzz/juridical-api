using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class LawyersConfiguration : IEntityTypeConfiguration<LawyersEntities>
    {
        public void Configure(EntityTypeBuilder<LawyersEntities> builder)
        {
            builder.HasData
            (
                new LawyersEntities
                {
                    Id = 1,
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