using CA_HastaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_HastaneOtomasyon.Interfaces
{
    public interface IOdalar
    {
        bool CreateOda(Odalar odaBilgisi);
        List<Odalar> GetAllOdalars();
        bool DeleteOda(int odaId);
        bool UpdateOda(Odalar updated);
    }
}
