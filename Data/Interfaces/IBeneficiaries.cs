using CupApplication.Data.Models;
using System.Collections.Generic;

namespace CupApplication.Data.Interfaces
{
    public interface IBeneficiaries
    {
        List<Beneficiaries> GetAllBeneficiariesContent();
        List<Beneficiaries> GetBeneficiaries();
        Beneficiaries getObject(int Id);
        public int? getIdByName(string name);

    }
}
