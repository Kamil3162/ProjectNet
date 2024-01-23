using System;
using System.Collections.Generic;

namespace Aplikacja2.Models;

public partial class Tagi
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; } = new List<Post>();
}
