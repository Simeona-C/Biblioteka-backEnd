using System;
using System.Collections.Generic;

namespace Biblioteka.BibliotekaModel;

public partial class Book
{
    public int Id { get; set; }

    public string Naslov { get; set; } = null!;

    public int AvtorId { get; set; }

    public string? IzdavackaKukja { get; set; }

    public int? Godina { get; set; }

    public int? Isbn { get; set; }

    public int KategorijaId { get; set; }

    public string? Jazik { get; set; }

    public string? Status { get; set; }

    public virtual Avtor Avtor { get; set; } = null!;

    public virtual Kategorija Kategorija { get; set; } = null!;

    public virtual ICollection<Lease> Leases { get; set; } = new List<Lease>();
}
