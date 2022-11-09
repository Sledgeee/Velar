using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Velar.Client.Components
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly List<string> _hrefs;

        public NavbarViewComponent()
        {
            _hrefs = new()
            {
                "Index", "Shop", "About", "Contact", "Faq"
            };
        }

        public IViewComponentResult Invoke()
        {
            return View(_hrefs);
        }
    }
}
