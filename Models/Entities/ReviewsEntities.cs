using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace juridical_api.Models.Entities
{
    public class ReviewsEntities
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Rating { get; set; } = 0;

        [Required]
        [StringLength(50)]
        public string Comment { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public Guid ClientId { get; set; }
        [JsonIgnore]
        public ClientsEntities? Client { get; set; }

        [Required]
        public Guid LawyerId { get; set; }
        [JsonIgnore]
        public LawyersEntities? Lawyer { get; set; }
    }
}