using System;
using System.Collections.Generic;

namespace CA_HastaneOtomasyon.Models;

public partial class Doktorlar
{
    public int Id { get; set; }

    public string DoktorAd { get; set; } = null!;

    public string DoktorSoyad { get; set; } = null!;

    public string UzmanlikAlani { get; set; } = null!;

    public DateTime? DiplomaTarihi { get; set; }

    public virtual Odalar? Odalar { get; set; }

    public virtual ICollection<Randevular> Randevulars { get; set; } = new List<Randevular>();
}
