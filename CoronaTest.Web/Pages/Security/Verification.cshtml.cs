using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaTest.Web.Pages.Security
{
    public class VerificationModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Der Token ist verpflichtend")]
        [Range(100000, 999999, ErrorMessage ="Der Token muss 6 stellig sein")]
        public int Token { get; set; }
        public void OnGet()
        {
        }
    }
}
