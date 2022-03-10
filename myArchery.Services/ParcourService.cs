using myArchery.Persistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myArchery.Services
{
    public static class ParcourService
    {
        public static int AddParcours(string name, string adress, int postalCode, string town, ICollection<ParcoursTarget> targets)
        {
            Parcour parcour = new Parcour
            {
                Name = name,
                StreetHousenumber = adress,
                Postalcode = postalCode,
                Town = town,
                ParcoursTargets = targets,
            };
            
            parcour.Counttargets = parcour.ParcoursTargets.Count;

            using (myarcheryContext db = new myarcheryContext())
            {
                db.Parcours.Add(parcour);
                return db.SaveChanges();
            }
        }

        public static Parcour ModifyParcour(int par_id, string? name = null, string? adress = null, int postalCode = 0, string? town = null, ICollection<ParcoursTarget>? targets = null)
        {
            var parcour = GetParcourById(par_id);

            parcour.Name = name ?? parcour.Name;
            parcour.StreetHousenumber = adress ?? parcour.StreetHousenumber;
            if (postalCode != 0)
            {
                parcour.Postalcode = postalCode;
            }
            parcour.Town = town ?? parcour.Town;
            parcour.ParcoursTargets = targets ?? parcour.ParcoursTargets;
            parcour.Counttargets = parcour.ParcoursTargets.Count();

            using (myarcheryContext db = new myarcheryContext())
            {
                db.Parcours.Update(parcour);
                db.SaveChanges();
            }
            
            return parcour;            
        }

        /// <summary>
        /// Get Parcour by Id
        /// </summary>
        /// <param name="par_id">Id of the Parcour</param>
        /// <returns>Returns the found Parcour</returns>
        public static Parcour GetParcourById(int par_id)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                return db.Parcours.First(x => x.ParId == par_id);
            }
        }

        public static int RemoveParcourById(int par_id)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                db.Parcours.Remove(GetParcourById(par_id));
                return db.SaveChanges();
            }
        }
    }
}
