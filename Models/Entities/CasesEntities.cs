using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace juridical_api.Models.Entities
{
    public class CasesEntities
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        public string CaseName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime OpeningDate { get; set; } 

        [Required]
        public Guid ClientId { get; set; }

        public ClientsEntities? Client { get; set; }

        [Required]
        public Guid LawyerId { get; set; }

        public LawyersEntities? Lawyers { get; set; }

        //FG keys

        public PaymentsEntities? Payments { get; set; }

        public TasksEntities? Tasks { get; set; }

        public DocumentsEntities? Documents { get; set; }

        public CourtHearingsEntities? CourtHearings { get; set; }
    }
}