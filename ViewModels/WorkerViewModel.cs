using System.Collections;
using System.Collections.Generic;
using CupApplication.Data.Models;

namespace CupApplication.Data.ViewModels
{
    public class WorkerViewModel
    {
        public IEnumerable<Drinks> AllDrinks { get; set; }
        public IEnumerable<Products> AllProducts { get; set; }
        public IEnumerable<Beneficiaries> AllBeneficiaries { get; set; }
    }
}
