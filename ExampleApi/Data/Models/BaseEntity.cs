﻿using ExampleApi.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleApi.Data.Models
{
    /// <summary>
    /// Base entity for all data models. In bigger projects, this model would probably be in a class library
    /// Could be an abstract class, instead of a class with an interface. Interface exists for the purpose to work with it on generic methods
    /// </summary>
    public class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid ConcurrenyToken { get; set; }
    }
}
