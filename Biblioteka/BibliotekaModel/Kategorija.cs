using System;
using System.Collections.Generic;

namespace Biblioteka.BibliotekaModel;

public partial class Kategorija
{
    public int Id { get; set; }

    public string Opis { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
