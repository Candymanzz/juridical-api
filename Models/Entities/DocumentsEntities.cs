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
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DocumentName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Required]
        [StringLength(25)]
        public string DocumentType { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string DocumentText { get; set; } = string.Empty;

        [Required]
        public Guid CaseId { get; set; }

        public CasesEntities? Case { get; set; }
    }
}