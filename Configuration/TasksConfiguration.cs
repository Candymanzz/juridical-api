using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class TasksConfiguration : IEntityTypeConfiguration<TasksEntities>
    {
        public void Configure(EntityTypeBuilder<TasksEntities> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Lawyer).WithOne(l => l.Task);
            builder.HasOne(t => t.Case).WithOne(cs => cs.Task);

            builder.HasData
            (
                new TasksEntities
                {
                    Id = new Guid("8B9658B8-49C1-423A-A807-71D1706710E9"),
                    TaskDescription = "Need more money",
                    DateOfCompletion = new DateTime(2004, 9, 19),
                    Status = "In progress",
                    CaseId = new Guid("8B9658B8-49C1-423A-A807-71D1706710E5"),
                    LawyerId = new Guid("8B9658B8-49C1-423A-A807-71D1706710E2")
                }
            );
        }
    }
}