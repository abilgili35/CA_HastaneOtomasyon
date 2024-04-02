using CA_HastaneOtomasyon.Interfaces;
using CA_HastaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CA_HastaneOtomasyon.Concretes
{
    public class HastalarConcrete : IHastalar
    {
        HastaneContext context = new HastaneContext();

        public bool CreateHasta(Hastalar hasta)
        {
            try
            {
                context.Hastalars.Add(hasta);

                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteHasta(int hastaId)
        {
            try
            {
                Hastalar deleted = context.Hastalars.Find(hastaId);
                HastaBilgileriConcrete hastaBilgileriConcrete = new HastaBilgileriConcrete();
                RandevularConcrete randevularConcrete = new RandevularConcrete();
                TahlilSonuclariConcrete tahlilSonuclariConcrete = new TahlilSonuclariConcrete();
                OdemelerConcrete odemelerConcrete = new OdemelerConcrete();

                if (deleted != null)
                {
                    hastaBilgileriConcrete.DeleteHastaBilgileri(hastaId);
                    randevularConcrete.DeleteRandevularByHastaId(hastaId);
                    tahlilSonuclariConcrete.DeleteTahlilSonuclariByHastaId(hastaId);
                    odemelerConcrete.DeleteOdemelerByHastaId(hastaId);
                    context.Hastalars.Remove(deleted);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Hastalar> GetAllHastalars()
        {
            return context.Hastalars.ToList();
        }

        public bool UpdateHasta(Hastalar updated)
        {
            try
            {
                Hastalar hasta = context.Hastalars.FirstOrDefault(x => x.Id == updated.Id);

                if (hasta != null)
                {
                    hasta.HastaAd = updated.HastaAd;
                    hasta.HastaSoyad = updated.HastaSoyad;
                    hasta.Tckn = updated.Tckn;

                    context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
