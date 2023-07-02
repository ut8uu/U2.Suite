using Microsoft.AspNetCore.Mvc;

namespace U2.WebApp;

public class CisController : Controller
{
	public IActionResult Index(
		[FromQuery] int pageIndex = 0,
		[FromQuery] string searchString = "",
		[FromQuery] string call = "")
	{
		var cisPage = new CisPage(pageIndex, searchString, call)
		{
			Calls = new CisCallList
			{
				new CisCallShort(1, "UT8UU"),
				new CisCallShort(2, "UT2UU"),
				new CisCallShort(3, "ZA7UU"),
			},
			CallInfo = new CisCallInfo
			{
				Id = 1,
				Call = "UT8UU",
				FirstName = "Sergey",
				LastName = "Usmanov",
			},
		};
		return View(cisPage);
	}
}
