using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Entities;

/// <summary>
/// Пользователь
/// </summary>
[Table("users")]
public class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Дата и время последней активности пользователя в UTC
    /// </summary>
    public DateTimeOffset LastActivityUtc { get; set; }

    public virtual ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}