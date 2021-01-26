using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CoronaTest.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaTest.Web.Pages.Security
{
    public class LoginModel : PageModel
    {
        private readonly ISmsService _smsService;

        [BindProperty]
        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [StringLength(10, ErrorMessage ="Die {0} genau 10 Zeichen lang sein!", MinimumLength = 10)]
        [DisplayName("SVNr")]
        public string SocialSecurityNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [StringLength(16, ErrorMessage = "Die {0} muss zwischen {1} und {2} Zeichen lang sein!", MinimumLength = 5)]
        [DisplayName("Handy-Nr")]
        public string Mobilnumber { get; set; }

        public LoginModel(ISmsService smsService)
        {
            _smsService = smsService;
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            if(SocialSecurityNumber != "0000080384")
            {
                ModelState.AddModelError(nameof(SocialSecurityNumber), "Diese SVNr ist unbekannt");
                return Page();
            }

            if (Mobilnumber != "+436643500902")
            {
                ModelState.AddModelError(nameof(Mobilnumber), "Diese Handy-Nr ist unbekannt i");
                return Page();
            }

            _smsService.SendSms(Mobilnumber, "Login erfolgreich!");

            return RedirectToPage("/Security/Verification"/*, new { token = myNewToken.identifier }*/);
        }
    }
}
