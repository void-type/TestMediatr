using architectureTest.Models.CoreModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace architectureTest.Models.CoreAspNet
{
    public class HttpActionResultResponder
    {
        public IActionResult Respond<TResponseSuccess>(ActionResponse<TResponseSuccess> response)
        {
            if (response.Failure.Any())
            {
                return new ObjectResult(response.Failure) { StatusCode = 400 };
            }
            else
            {
                return new ObjectResult(response.Success) { StatusCode = 200 };
            }
        }
    }
}
