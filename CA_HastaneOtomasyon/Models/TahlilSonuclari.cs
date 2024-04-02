using System;
using System.Collections.Generic;

namespace CA_HastaneOtomasyon.Models;

public partial class TahlilSonuclari
{
    public int Id { get; set; }

    public DateTime TahlilZamani { get; set; }

    public string TahlilDosyaLinki { get; set; } = null!;

    public int HastaId { get; set; }

    public virtual Hastalar Hasta { get; set; } = null!;
}
