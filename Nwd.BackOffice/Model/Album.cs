using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Nwd.BackOffice.Model
{
    public class Album
    {
        [Display(Name="Id")]
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Titre de l'album")]
        public string Title { get; set; }

        [Display(Name = "Année de sortie")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Type d'album")]
        public string Type { get; set; }

        [Display(Name = "Image de l'album")]
        public string CoverImagePath { get; set; }

        [Required]
        [Display(Name = "Artiste principal")]
        public virtual Artist Artist { get; set; }

        [Required]
        [Display(Name = "Pistes audio")]
        public virtual ICollection<Track> Tracks { get; set; }

        [Display(Name = "Durée totale")]
        public TimeSpan Duration { get; set; }

        [Required]
        [Display(Name = "URL du fichier")]
        [NotMapped]
        public HttpPostedFileBase CoverFile { get; set; }
    }
}
