using CA_HastaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_HastaneOtomasyon.Interfaces
{
    public interface IDoktorlar
    {
        bool CreateDoktor(Doktorlar doktor);
        List<Doktorlar> GetAllDoktorlars();
        bool DeleteDoktor(int doktorId);
        bool UpdateDoktor(Doktorlar updated);
    }
}
