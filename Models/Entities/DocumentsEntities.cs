using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace juridical_api.Models.Entities
{
    public class DocumentsEntities
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DocumentName { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        [StringLength(25)]
        public string DocumentType { get; set; }

        [Required]
        public int CaseId { get; set; }

        public virtual CasesEntities Case { get; set; }
    }
}