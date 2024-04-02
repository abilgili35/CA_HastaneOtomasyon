using CA_HastaneOtomasyon.Interfaces;
using CA_HastaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_HastaneOtomasyon.Concretes
{
    public class DoktorlarConcrete : IDoktorlar
    {
        HastaneContext context = new HastaneContext();

        public bool CreateDoktor(Doktorlar doktor)
        {
            try
            {
                context.Doktorlars.Add(doktor);

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

        public bool DeleteDoktor(int doktorId)
        {
            try
            {
                Doktorlar deleted = context.Doktorlars.Find(doktorId);
                OdalarConcrete odalar = new OdalarConcrete();
                RandevularConcrete randevularConcrete = new RandevularConcrete();

                if (deleted != null)
                {
                    odalar.DeleteOda(doktorId);
                    randevularConcrete.DeleteRandevularByDoktorId(doktorId);
                    context.Doktorlars.Remove(deleted);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            
        }

        public List<Doktorlar> GetAllDoktorlars()
        {
            return context.Doktorlars.ToList();
        }

        public bool UpdateDoktor(Doktorlar updated)
        {
            try
            {
                Doktorlar doktor = context.Doktorlars.FirstOrDefault(x => x.Id == updated.Id);

                if (doktor != null)
                {
                    doktor.DoktorAd = updated.DoktorAd;
                    doktor.DoktorSoyad = updated.DoktorSoyad;
                    doktor.UzmanlikAlani = updated.UzmanlikAlani;
                    doktor.DiplomaTarihi = updated.DiplomaTarihi;

                    context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            
        }
    }
}
