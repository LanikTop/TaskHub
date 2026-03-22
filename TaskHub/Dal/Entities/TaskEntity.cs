using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Entities
{
    [Table("tasks")]
    public class TaskEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("created_by_user_id")]
        public Guid CreatedByUserId { get; set; }

        [Column("created_utc")]
        public DateTimeOffset CreatedUtc { get; set; }
        public virtual User? User { get; set; }
    }
}
