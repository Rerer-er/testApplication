﻿using System.ComponentModel.DataAnnotations;

namespace Entities.ModelsDto
{
    public class UpdateKindDto
    {
        [Required(ErrorMessage = "Kind name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kind about is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the about is 60 characters.")]
        public string About { get; set; }

        public string Foto { get; set; }
    }
}
