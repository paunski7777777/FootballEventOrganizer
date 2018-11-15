﻿namespace Footeo.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Referee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        [Required]
        [Range(18, 50)]
        public int Age { get; set; }

        [Required]
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public virtual Town Town { get; set; }

        public virtual ICollection<Match> Matches { get; set; }

        public Referee()
        {
            this.Matches = new List<Match>();
        }
    }
}