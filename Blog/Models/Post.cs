using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Titre { get; set; }

        [DisplayName ("Article")]
        public string Contenu { get; set; }

        [DisplayName("Date de creation")]
        public DateTime DateCreation { get; set; }

        [DisplayName("Date de modification")]
        public DateTime DateModification { get; set; }
        
        public bool Supprimer { get; set; }

    }
}