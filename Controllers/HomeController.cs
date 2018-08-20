using architectureTest.Models;
using architectureTest.Models.CoreAspNet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace architectureTest.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(HttpActionResultResponder responder, IMediator mediator)
        {
            _mediator = mediator;
            _responder = responder;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ApiEndpoint(string name)
        {
            var request = new GetLoanee.Request { Name = name };
            var response = await _mediator.Send(request);
            return _responder.Respond(response);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
        private readonly IMediator _mediator;
        private readonly HttpActionResultResponder _responder;
    }
}
