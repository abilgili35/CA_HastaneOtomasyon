using System;
using System.Collections.Generic;

namespace CA_HastaneOtomasyon.Models;

public partial class HastaBilgileri
{
    public int Id { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public double? Boy { get; set; }

    public double? Kilo { get; set; }

    public string? Email { get; set; }

    public string? Adres { get; set; }

    public string? TelefonNo { get; set; }

    public virtual Hastalar IdNavigation { get; set; } = null!;
}
