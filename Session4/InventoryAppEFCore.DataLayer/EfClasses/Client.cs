﻿using System.ComponentModel.DataAnnotations;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedOn { get; private set; }

        public string NameAndCreatedOn { get; private set; }

        public int ComputedBirthYear { get; set; }


    }
}
