using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Aplikacja2.Models
{
    public class PostKategorie
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int KategoriaId { get; set; }
        public Kategorie Kategoria { get; set; }
    }
}
