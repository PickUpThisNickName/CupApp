using System.Collections.Generic;

namespace CupApplication.Data.Models
{
    public class BenefitType
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public float Koefficient { get; set; }

        public List<Beneficiaries> Persons { get; set; }
    }
}
