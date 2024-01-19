using System;
using System.Collections.Generic;

namespace Biblioteka.BibliotekaModel;

public partial class Avtor
{
    public int Id { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public int? GodinaNaRagjanje { get; set; }

    public string? Zemja { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
