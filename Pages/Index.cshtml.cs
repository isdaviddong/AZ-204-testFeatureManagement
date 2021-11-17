using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

namespace testToggle.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        public bool isEnabled = false;
        public readonly IConfiguration Configuration;
        public IndexModel(IConfiguration configuration, IFeatureManager featureManager)
        {
            Configuration = configuration;

            if (featureManager != null)
                isEnabled = featureManager.IsEnabledAsync("toggle01").Result;
        }

        public void OnGet()
        {

        }
    }
}
