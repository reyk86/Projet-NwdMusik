﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Nwd.BackOffice.Model
{
    public class Artist
    {
        public int? Id { get; set; }

        [Display(Name = "Nom de l'artiste")]
        public string Name { get; set; }

        [Display(Name = "Biographie de l'artiste")]
        public string Biography { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
