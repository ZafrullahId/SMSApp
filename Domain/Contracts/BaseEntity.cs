using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Contracts
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
