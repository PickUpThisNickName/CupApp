using CupApplication.Data.Models;
using System.Collections.Generic;

namespace CupApplication.Data.Interfaces
{
    public interface IBenefitType
    {
        List<BenefitType> GetAllBenefitTypesContent();
        BenefitType getObject(int Id);

    }
}
