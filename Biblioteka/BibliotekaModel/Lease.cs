using System;
using System.Collections.Generic;

namespace Biblioteka.BibliotekaModel;

public partial class Lease
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int MemberId { get; set; }

    public DateOnly DateLeased { get; set; }

    public DateOnly? DateReturned { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
