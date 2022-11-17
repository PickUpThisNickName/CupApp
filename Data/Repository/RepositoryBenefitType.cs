using System.Collections.Generic;
using System.Linq;
using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;

namespace CupApplication.Data.Repository
{
    public class RepositoryBenefitType : IBenefitType
    {
        private readonly AppDBContent content;
        public RepositoryBenefitType(AppDBContent appDBContent)
        {
            this.content = appDBContent;
        }

        public List<BenefitType> GetAllBenefitTypesContent()
        {
            return (from p in content.DB_BenefitType
                    select new BenefitType
                    {
                        Id = p.Id,
                        Group = p.Group,
                        Koefficient = p.Koefficient
                    }).ToList();
        }

        BenefitType IBenefitType.getObject(int Id)
        {
            return content.DB_BenefitType.FirstOrDefault(p => p.Id == Id);
        }
    }
}
