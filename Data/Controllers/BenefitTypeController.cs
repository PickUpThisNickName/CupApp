using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CupApplication.Data.Controllers
{
    [Authorize(Roles = "admin")]
    public class BenefitTypeController : Controller
    {
        private readonly IBenefitType _benefitType;

        public BenefitTypeController(IBenefitType benefitType)
        {
            _benefitType = benefitType;
        }
        [Route("Table2")]
        public ViewResult Table()
        {
            return View(_benefitType.GetAllBenefitTypesContent());
        }
    }
}
