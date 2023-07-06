using System;
using System.ComponentModel.DataAnnotations;

namespace Valtegy.Domain.Entities
{
    public class ActivityType
    {
        [Required]
        public Guid Id { get; set; }

        [Key]
        [Required]
        public int ActivityTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
