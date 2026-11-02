using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceDTO.models
{
        [Index(nameof(TokenHash), IsUnique = true)]
        public class RefreshToken
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [MaxLength(128)]
            public required string TokenHash { get; set; }

            public int UserId { get; set; }

            [ForeignKey(nameof(UserId))]
            public User? User { get; set; }

            public DateTime ExpiresAt { get; set; }

            public DateTime? RevokedAt { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        }
    
}

