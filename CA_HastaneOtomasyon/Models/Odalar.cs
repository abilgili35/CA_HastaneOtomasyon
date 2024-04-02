using System;
using System.Collections.Generic;

namespace CA_HastaneOtomasyon.Models;

public partial class Odalar
{
    public int Id { get; set; }

    public byte BinaNo { get; set; }

    public byte KatNo { get; set; }

    public byte OdaNo { get; set; }

    public virtual Doktorlar IdNavigation { get; set; } = null!;
}
