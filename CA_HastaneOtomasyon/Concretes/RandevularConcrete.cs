using CA_HastaneOtomasyon.Interfaces;
using CA_HastaneOtomasyon.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_HastaneOtomasyon.Concretes
{
    public class RandevularConcrete : IRandevular
    {
        HastaneContext context = new HastaneContext();

        public bool CreateRandevu(Randevular randevu)
        {
            try
            {
                context.Randevulars.Add(randevu);

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

        public bool DeleteRandevu(int randevuId)
        {
            try
            {
                Randevular deleted = context.Randevulars.Find(randevuId);

                if (deleted != null)
                {
                    context.Randevulars.Remove(deleted);
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

        public bool DeleteRandevularByDoktorId(int doktorId)
        {
            try
            {
                List<Randevular> deletedList = context.Randevulars.Where(x => x.DoktorId == doktorId).ToList();

                if (deletedList.Count != 0)
                {

                    foreach (Randevular randevu in deletedList)
                    {
                        context.Randevulars.Remove(randevu);
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

        public bool DeleteRandevularByHastaId(int hastaId)
        {
            try
            {
                List<Randevular> deletedList = context.Randevulars.Where(x => x.HastaId == hastaId).ToList();

                if (deletedList.Count != 0)
                {

                    foreach(Randevular randevu in deletedList)
                    {
                        context.Randevulars.Remove(randevu);
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

        public List<Randevular> GetAllRandevulars()
        {
            return context.Randevulars.ToList();
        }

        public bool UpdateRandevu(Randevular updated)
        {
            try
            {
                Randevular randevu = context.Randevulars.FirstOrDefault(x => x.Id == updated.Id);

                if (randevu != null)
                {
                    randevu.DoktorId = updated.DoktorId;
                    randevu.HastaId = updated.HastaId;
                    randevu.RandevuZamani = updated.RandevuZamani;

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
