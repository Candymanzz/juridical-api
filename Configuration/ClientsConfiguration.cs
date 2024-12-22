using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class ClientsConfiguration : IEntityTypeConfiguration<ClientsEntities>
    {
        public void Configure(EntityTypeBuilder<ClientsEntities> builder)
        {
            builder.HasData
            (
                new ClientsEntities
                {
                    Id = 1,
                    FirstName = "Slava",
                    LastName = "Spanish",
                    Email = "Dadaya@gmail.com",
                    Phone = "+3226232109",
                    Address = "Nemecia, Frankich 22 / 1"
                }
            );
        }
    }
}