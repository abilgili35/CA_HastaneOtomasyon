using CA_HastaneOtomasyon.Interfaces;
using CA_HastaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_HastaneOtomasyon.Concretes
{
    public class TahlilSonuclariConcrete : ITahlilSonuclari
    {
        HastaneContext context = new HastaneContext();

        public bool CreateTahlilSonucu(TahlilSonuclari tahlilSonucu)
        {
            try
            {
                context.TahlilSonuclaris.Add(tahlilSonucu);

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

        public bool DeleteTahlilSonuclariByHastaId(int hastaId)
        {
            try
            {
                List<TahlilSonuclari> deletedList = context.TahlilSonuclaris.Where(x => x.HastaId == hastaId).ToList();

                if (deletedList.Count != 0)
                {

                    foreach (TahlilSonuclari tahlilSonucu in deletedList)
                    {
                        context.TahlilSonuclaris.Remove(tahlilSonucu);
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

        public bool DeleteTahlilSonucu(int tahlilSonucuId)
        {
            try
            {
                TahlilSonuclari deleted = context.TahlilSonuclaris.Find(tahlilSonucuId);

                if (deleted != null)
                {
                    context.TahlilSonuclaris.Remove(deleted);
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

        public List<TahlilSonuclari> GetAllTahlilSonuclaris()
        {
            return context.TahlilSonuclaris.ToList();
        }

        public bool UpdateTahlilSonucu(TahlilSonuclari updated)
        {
            try
            {
                TahlilSonuclari tahlilSonucu = context.TahlilSonuclaris.FirstOrDefault(x => x.Id == updated.Id);

                if (tahlilSonucu != null)
                {
                    tahlilSonucu.TahlilZamani = updated.TahlilZamani;
                    tahlilSonucu.TahlilDosyaLinki = updated.TahlilDosyaLinki;
                    tahlilSonucu.HastaId = updated.HastaId;

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
