using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace juridical_api.Models.Entities
{
    public class CourtHearingsEntities
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime HearingDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Place { get; set; } = string.Empty;

        [Required]
        public Guid CaseId { get; set; }
        [JsonIgnore]
        public CasesEntities? Case { get; set; }
    }
}