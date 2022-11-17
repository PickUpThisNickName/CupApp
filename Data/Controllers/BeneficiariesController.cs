using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CupApplication.Data.Controllers
{
    [Authorize(Roles = "admin")]
    public class BeneficiariesController : Controller
    {
        private readonly IBeneficiaries _beneficiaries;

        public BeneficiariesController(IBeneficiaries beneficiaries)
        {
            _beneficiaries = beneficiaries;
        }
        [Route("Table1")]
        public ViewResult Table()
        {
            return View(_beneficiaries.GetAllBeneficiariesContent());
        }
    }
}
