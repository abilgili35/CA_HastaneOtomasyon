using CA_HastaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_HastaneOtomasyon.Interfaces
{
    public interface IRandevular
    {
        bool DeleteRandevularByDoktorId(int doktorId);
        bool DeleteRandevularByHastaId(int hastaId);
        List<Randevular> GetAllRandevulars();
        bool CreateRandevu(Randevular randevu);
        bool DeleteRandevu(int randevuId);
        bool UpdateRandevu(Randevular updated);
    }
}
