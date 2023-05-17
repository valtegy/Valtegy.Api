using System;
using System.ComponentModel.DataAnnotations;

namespace Valtegy.Domain.Entities
{
    public class AuditBase
    {
        [Required]
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }

        [Required]
        public Guid UserIdCreated { get; set; }
        public Guid? UserIdUpdated { get; set; }

        [Required]
        public bool IsEnabled { get; set; }
    }
}
