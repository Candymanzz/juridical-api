using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class TasksConfiguration : IEntityTypeConfiguration<TasksEntities>
    {
        public void Configure(EntityTypeBuilder<TasksEntities> builder)
        {
            builder.HasData
            (
                new TasksEntities
                {
                    Id = 1,
                    TaskDescription = "Need more money",
                    DateOfCompletion = new DateTime(2004, 9, 19),
                    Status = "In progress",
                    CaseId = 1,
                    LawyerId = 1
                }
            );
        }
    }
}