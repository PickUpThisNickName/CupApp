using System.Collections.Generic;
using System.Linq;
using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CupApplication.Data.Repository
{
    public class RepositoryBeneficiaries : IBeneficiaries
    {
        private readonly AppDBContent content;
        public RepositoryBeneficiaries(AppDBContent appDBContent)
        {
            this.content = appDBContent;
        }

        public List<Beneficiaries> GetAllBeneficiariesContent()
        {
            return (from p in content.DB_Beneficiaries
                    select new Beneficiaries
                    {
                        Id = p.Id,
                        Name = p.Name,
                        GroupObj = p.GroupObj
                    }).ToList();
        }

        public List<Beneficiaries> GetBeneficiaries()
        {
            return (from p in content.DB_Beneficiaries
                    select new Beneficiaries
                    {
                        Name = p.Name,
                    }).ToList();
        }

        public Beneficiaries getObject(int Id)
        {
            return content.DB_Beneficiaries.FirstOrDefault(p => p.Id == Id);
        }
        public int? getIdByName(string name)
        {
            Beneficiaries benef = new Beneficiaries();
            if (name!=null)
                benef = content.DB_Beneficiaries.FirstOrDefault(p => p.Name == name);
            return benef.Id;
        }
        public float? GetKoefficient(int? Id)
        {
            Beneficiaries benef = new Beneficiaries();
            if (Id != null)
            {
                benef = content.DB_Beneficiaries.Include(b => b.GroupObj).FirstOrDefault(p => p.Id == Id);
                return benef.GroupObj.Koefficient;
            }
            else
                return 0;
        }

    }
}
