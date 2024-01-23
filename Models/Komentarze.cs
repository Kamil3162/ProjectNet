using System;
using System.Collections.Generic;

namespace Aplikacja2.Models;

public partial class Komentarze
{
    public int Id { get; set; }

    public string Tresc { get; set; } = null!;

    public int? UzytkownikId { get; set; }

    public int? PostId { get; set; }

    public virtual Post? Post { get; set; }

    public virtual Uzytkownicy? Uzytkownik { get; set; }
}
