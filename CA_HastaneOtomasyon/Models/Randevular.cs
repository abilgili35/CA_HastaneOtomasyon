using System;
using System.Collections.Generic;

namespace CA_HastaneOtomasyon.Models;

public partial class Randevular
{
    public int Id { get; set; }

    public int DoktorId { get; set; }

    public int HastaId { get; set; }

    public DateTime RandevuZamani { get; set; }

    public virtual Doktorlar Doktor { get; set; } = null!;

    public virtual Hastalar Hasta { get; set; } = null!;
}
