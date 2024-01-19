using System;
using System.Collections.Generic;

namespace Biblioteka.BibliotekaModel;

public partial class Member
{
    public int Id { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public int TelefonskiBroj { get; set; }

    public virtual ICollection<Lease> Leases { get; set; } = new List<Lease>();
}
