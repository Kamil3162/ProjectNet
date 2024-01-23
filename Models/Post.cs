using System;
using System.Collections.Generic;

namespace Aplikacja2.Models;

public partial class Post
{
    public int Id { get; set; }

    public string Tytul { get; set; } = null!;

    public string Tresc { get; set; } = null!;

    public DateTime DataUtworzenia { get; set; }

    public int? UzytkownikId { get; set; }

    public virtual ICollection<Komentarze> Komentarzes { get; } = new List<Komentarze>();

    public virtual Uzytkownicy? Uzytkownik { get; set; }

    public virtual ICollection<Kategorie> Kategoria { get; } = new List<Kategorie>();

    public virtual ICollection<Tagi> Tags { get; } = new List<Tagi>();

    public virtual ICollection<PostKategorie> PostKategorie { get; } = new List<PostKategorie>();

}
