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
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TaskDescription { get; set; }

        [Required]
        public DateTime DateOfCompletion { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int CaseId { get; set; }

        public virtual CasesEntities Case { get; set; }

        [Required]
        public int LawyerId { get; set; }

        public virtual LawyersEntities Lawyer { get; set; }
    }
}