using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace juridical_api.Models.Entities
{
    public class PaymentsEntities
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(20)]
        public string PaymentMethod { get; set; }

        [Required]
        public int ClientId { get; set; }

        public virtual ClientsEntities Client { get; set; }

        [Required]
        public int CaseId { get; set; }

        public virtual CasesEntities Case { get; set; }
    }
}