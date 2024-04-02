using CA_HastaneOtomasyon.Interfaces;
using CA_HastaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_HastaneOtomasyon.Concretes
{
    public class OdalarConcrete : IOdalar
    {
        HastaneContext context = new HastaneContext();

        public bool CreateOda(Odalar odaBilgisi)
        {
            try
            {
                context.Odalars.Add(odaBilgisi);

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

        public bool DeleteOda(int odaId)
        {
            try
            {
                Odalar deleted = context.Odalars.Find(odaId);

                if (deleted != null)
                {
                    context.Odalars.Remove(deleted);
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

        public List<Odalar> GetAllOdalars()
        {
            return context.Odalars.ToList();
        }

        public bool UpdateOda(Odalar updated)
        {
            try
            {
                Odalar odaBilgileri = context.Odalars.FirstOrDefault(x => x.Id == updated.Id);

                if (odaBilgileri != null)
                {
                    odaBilgileri.BinaNo = updated.BinaNo;
                    odaBilgileri.KatNo = updated.KatNo;
                    odaBilgileri.OdaNo = updated.OdaNo;
                    

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
