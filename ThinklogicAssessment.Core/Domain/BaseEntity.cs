﻿
namespace ThinklogicAssessment.Core.Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
