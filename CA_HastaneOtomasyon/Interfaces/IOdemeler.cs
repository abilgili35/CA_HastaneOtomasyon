using CA_HastaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_HastaneOtomasyon.Interfaces
{
    public interface IOdemeler
    {
        bool DeleteOdemelerByHastaId(int hastaId);
        List<Odemeler> GetAllOdemelers();
        bool CreateOdeme(Odemeler odeme);
        bool DeleteOdeme(int odemeId);
        bool UpdateOdeme(Odemeler updated);
    }
}
