using coresuite_asp_dotnet_framework_mvc_cs.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace coresuite_asp_dotnet_framework_mvc_cs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult MergerInvoice()
        {
            return View();
        }

        public ActionResult SelectPages()
        {
            return View();
        }

        public ActionResult AcroFormFill()
        {
            W9FormModel w9 = new W9FormModel();
            return View(w9);
        }

        public ActionResult USEnvelope()
        {
            EnvelopeModel envelope = new EnvelopeModel();
            return View(envelope);
        }

        public ActionResult FormFill()
        {
            W9FormModel w9 = new W9FormModel();
            return View(w9);
        }

        public ActionResult TextExtraction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExtractText()
        {
            return Content(CodeFiles.ExtractText.Run());
        }

        [HttpPost]
        public ActionResult CreateInvoice(FormCollection collection)
        {
            List<string> selected = new List<string>();
            foreach (string key in collection.AllKeys)
            {
                if (collection[key].StartsWith("true"))
                    selected.Add(key);
            }

            byte[] pdf = CodeFiles.Invoice.Run(selected);
            return File(pdf, "application/pdf");
        }

        [HttpPost]
        public ActionResult CreateMergerInvoice(FormCollection collection)
        {
            List<string> selected = new List<string>();
            foreach (string key in collection.AllKeys)
            {
                if (collection[key].StartsWith("true"))
                    selected.Add(key);
            }

            byte[] pdf = CodeFiles.Invoice.RunMerger(selected);
            return File(pdf, "application/pdf");
        }

        [HttpPost]
        public ActionResult CreateEnvelope(EnvelopeModel envelope)
        {
            byte[] pdf = CodeFiles.USEnvelope.Run(envelope);
            return File(pdf, "application/pdf");
        }

        [HttpPost]
        public ActionResult AcroFormFillW9(W9FormModel w9FormData)
        {
            byte[] pdf = CodeFiles.AcroFormFillW9.Run(w9FormData);
            return File(pdf, "application/pdf");
        }

        [HttpPost]
        public ActionResult FormFillW9(W9FormModel w9FormData)
        {
            byte[] pdf = CodeFiles.AcroFormFillW9.RunFormFill(w9FormData);
            return File(pdf, "application/pdf");
        }

        [HttpPost]
        public ActionResult SelectPages(FormCollection collection)
        {
            List<string> selected = new List<string>();
            foreach (string key in collection.AllKeys)
            {
                if (collection[key].StartsWith("true"))
                    selected.Add(key);
            }

            byte[] pdf = CodeFiles.SelectPages.Run(selected);
            return File(pdf, "application/pdf");
        }
    }
}