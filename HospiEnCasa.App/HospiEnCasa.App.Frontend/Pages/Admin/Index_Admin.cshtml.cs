using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.Frontend.Pages
{
    [Authorize]
    public class Index_AdminModel : PageModel
    {
        private readonly ILogger<Index_AdminModel> _logger;

        public Index_AdminModel(ILogger<Index_AdminModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
