using Biblioteka.BibliotekaModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Interfaces
{
    public interface ILibraryContext
    {
        DbSet<Avtor> Avtors { get; set; }

        DbSet<Book> Books { get; set; }

        DbSet<Kategorija> Kategorijas { get; set; }

        DbSet<Lease> Leases { get; set; }

        DbSet<Member> Members { get; set; }

        // OnConfiguring(DbContextOptionsBuilder optionsBuilder);
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
         //   => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DMURBSB;Initial Catalog=Library;Integrated Security=True;Trust Server Certificate=True");

        //void OnModelCreating(ModelBuilder modelBuilder);
 
        //void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
