using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace juridical_api.Entities
{
    public class CourtHearingsEntities
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime HearingDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Place { get; set; }

        [Required]
        public int CaseId { get; set; }

        public virtual CasesEntities Case { get; set; }
    }
}