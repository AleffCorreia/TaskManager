using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}
