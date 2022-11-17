using System.Collections.Generic;
using System.Linq;
using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;

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
                        Group = p.Group
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
    }
}
