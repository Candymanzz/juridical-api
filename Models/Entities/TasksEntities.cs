using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace juridical_api.Models.Entities
{
    public class TasksEntities
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TaskDescription { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfCompletion { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public Guid CaseId { get; set; }

        public CasesEntities? Case { get; set; }

        [Required]
        public Guid LawyerId { get; set; }

        public LawyersEntities? Lawyer { get; set; }
    }
}