using System;
using System.Collections.Generic;

namespace CA_HastaneOtomasyon.Models;

public partial class Odemeler
{
    public int Id { get; set; }

    public int HastaId { get; set; }

    public DateTime OdemeTarihi { get; set; }

    public decimal Miktar { get; set; }

    public virtual Hastalar Hasta { get; set; } = null!;
}
