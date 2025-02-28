using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace juridical_api.Models.Entities
{
    public class PaymentsEntities
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; } = 0;

        [Required]
        [StringLength(20)]
        public string PaymentMethod { get; set; } = string.Empty;

        [Required]
        public Guid ClientId { get; set; }
        [JsonIgnore]
        public ClientsEntities? Client { get; set; }

        [Required]
        public Guid CaseId { get; set; }
        [JsonIgnore]
        public CasesEntities? Case { get; set; }
    }
}