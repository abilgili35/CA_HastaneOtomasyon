using System;
using System.Collections.Generic;

namespace CA_HastaneOtomasyon.Models;

public partial class Hastalar
{
    public int Id { get; set; }

    public string HastaAd { get; set; } = null!;

    public string? HastaSoyad { get; set; }

    public string Tckn { get; set; } = null!;

    public virtual HastaBilgileri? HastaBilgileri { get; set; }

    public virtual ICollection<Odemeler> Odemelers { get; set; } = new List<Odemeler>();

    public virtual ICollection<Randevular> Randevulars { get; set; } = new List<Randevular>();

    public virtual ICollection<TahlilSonuclari> TahlilSonuclaris { get; set; } = new List<TahlilSonuclari>();
}
