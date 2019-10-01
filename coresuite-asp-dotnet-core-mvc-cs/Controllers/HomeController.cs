using coresuite_asp_dotnet_core_mvc_cs.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace coresuite_asp_dotnet_core_cs.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment currentEnvironment;

        private IConfiguration currentConfiguration;

        public HomeController(IConfiguration configuration, IHostingEnvironment env)
        {
            currentConfiguration = configuration;
            currentEnvironment = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Invoice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateInvoice(IFormCollection collection)
        {
            List<string> selected = new List<string>();
            foreach (string key in collection.Keys)
            {
                if (collection[key].FirstOrDefault(t => t.Contains("true")) != null)
                    selected.Add(key);
            }
            byte[] pdf = coresuite_asp_dotnet_core_mvc_cs.CodeFiles.Invoice.Run(selected, currentConfiguration.GetConnectionString("NorthWindConnectionString"), currentEnvironment);
            return File(pdf, "application/pdf");
        }

        public IActionResult MergerInvoice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMergerInvoice(IFormCollection collection)
        {
            List<string> selected = new List<string>();
            foreach (string key in collection.Keys)
            {
                if (collection[key].FirstOrDefault(t => t.Contains("true")) != null)
                    selected.Add(key);
            }

            byte[] pdf = coresuite_asp_dotnet_core_mvc_cs.CodeFiles.Invoice.RunMerger(selected, currentConfiguration.GetConnectionString("NorthWindConnectionString"), currentEnvironment);
            return File(pdf, "application/pdf");
        }

        public IActionResult SelectPages()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectPages(IFormCollection collection)
        {
            List<string> selected = new List<string>();
            foreach (string key in collection.Keys)
            {
                if (collection[key].FirstOrDefault(t => t.Contains("true")) != null)
                    selected.Add(key);
            }

            byte[] pdf = coresuite_asp_dotnet_core_mvc_cs.CodeFiles.SelectPages.Run(selected, currentEnvironment);
            return File(pdf, "application/pdf");
        }

        public IActionResult AcroFormFill()
        {
            W9FormModel w9 = new W9FormModel();
            return View(w9);
        }

        [HttpPost]
        public IActionResult AcroFormFillW9(W9FormModel w9FormData)
        {
            byte[] pdf = coresuite_asp_dotnet_core_mvc_cs.CodeFiles.AcroFormFillW9.Run(w9FormData, currentEnvironment);
            return File(pdf, "application/pdf");
        }

        public IActionResult USEnvelope()
        {
            EnvelopeModel envelope = new EnvelopeModel();
            return View(envelope);
        }

        [HttpPost]
        public IActionResult CreateEnvelope(EnvelopeModel envelope)
        {
            byte[] pdf = coresuite_asp_dotnet_core_mvc_cs.CodeFiles.USEnvelope.Run(envelope, currentEnvironment);
            return File(pdf, "application/pdf");
        }

        public IActionResult FormFill()
        {
            W9FormModel w9 = new W9FormModel();
            return View(w9);
        }

        [HttpPost]
        public IActionResult FormFillW9(W9FormModel w9FormData)
        {
            byte[] pdf = coresuite_asp_dotnet_core_mvc_cs.CodeFiles.AcroFormFillW9.RunFormFill(w9FormData, currentEnvironment);
            return File(pdf, "application/pdf");
        }

        public IActionResult TextExtraction()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExtractText()
        {
            return Content(coresuite_asp_dotnet_core_mvc_cs.CodeFiles.ExtractText.Run(currentEnvironment));
        }
    }
}