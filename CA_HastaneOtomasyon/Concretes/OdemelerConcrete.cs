using CA_HastaneOtomasyon.Interfaces;
using CA_HastaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_HastaneOtomasyon.Concretes
{
    public class OdemelerConcrete : IOdemeler
    {
        HastaneContext context = new HastaneContext();

        public bool CreateOdeme(Odemeler odeme)
        {
            try
            {
                context.Odemelers.Add(odeme);

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

        public bool DeleteOdeme(int odemeId)
        {
            try
            {
                Odemeler deleted = context.Odemelers.Find(odemeId);

                if (deleted != null)
                {
                    context.Odemelers.Remove(deleted);
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

        public bool DeleteOdemelerByHastaId(int hastaId)
        {
            try
            {
                List<Odemeler> deletedList = context.Odemelers.Where(x => x.HastaId == hastaId).ToList();

                if (deletedList.Count != 0)
                {

                    foreach (Odemeler odeme in deletedList)
                    {
                        context.Odemelers.Remove(odeme);
                    }

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

        public List<Odemeler> GetAllOdemelers()
        {
            return context.Odemelers.ToList();
        }

        public bool UpdateOdeme(Odemeler updated)
        {
            try
            {
                Odemeler odeme = context.Odemelers.FirstOrDefault(x => x.Id == updated.Id);

                if (odeme != null)
                {
                    odeme.HastaId = updated.HastaId;
                    odeme.OdemeTarihi = updated.OdemeTarihi;
                    odeme.Miktar = updated.Miktar;

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
