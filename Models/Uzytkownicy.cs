using System;
using System.Collections.Generic;

namespace Aplikacja2.Models;

public partial class Uzytkownicy
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Haslo { get; set; } = null!;

    public virtual ICollection<Komentarze> Komentarzes { get; } = new List<Komentarze>();

    public virtual ICollection<Post> Posts { get; } = new List<Post>();
}
