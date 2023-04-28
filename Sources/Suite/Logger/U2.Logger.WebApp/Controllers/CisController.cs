using Microsoft.AspNetCore.Mvc;

namespace U2.Logger.WebApp;

public class CisController : Controller
{
    public IActionResult Index(
        [FromQuery] int pageIndex = 0, 
        [FromQuery] string searchString = "",
        [FromQuery] string call = "")
    {
        var cisPage = new CisPage(pageIndex, searchString, call);

        cisPage.Calls = new CisCallList
        {
            new CisCallShort(1, "UT8UU"),
        };
        return View(cisPage);
    }
}
