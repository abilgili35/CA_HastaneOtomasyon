using CA_HastaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_HastaneOtomasyon.Interfaces
{
    public interface ITahlilSonuclari
    {
        bool DeleteTahlilSonuclariByHastaId(int hastaId);
        List<TahlilSonuclari> GetAllTahlilSonuclaris();
        bool CreateTahlilSonucu(TahlilSonuclari tahlilSonucu);
        bool DeleteTahlilSonucu(int tahlilSonucuId);
        bool UpdateTahlilSonucu(TahlilSonuclari updated);
    }
}
