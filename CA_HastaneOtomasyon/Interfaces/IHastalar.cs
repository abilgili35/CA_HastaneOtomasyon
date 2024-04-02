using CA_HastaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_HastaneOtomasyon.Interfaces
{
    public interface IHastalar
    {
        bool CreateHasta(Hastalar hasta);
        List<Hastalar> GetAllHastalars();
        bool DeleteHasta(int hastaId);
        bool UpdateHasta(Hastalar updated);
    }
}
