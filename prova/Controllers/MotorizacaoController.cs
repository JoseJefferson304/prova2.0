using Microsoft.JScript;
using prova.App_Start.Models;
using prova.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace prova.Controllers
{
    public class MotorizacaoController : Controller
    {
        private EFContext context = new EFContext();
        public ActionResult Index()
        {
            return View(
                context.Motorizacaos.OrderBy(c => c.Modelo)
                );
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Motorizacao motorizacao)
        {
            context.Motorizacaos.Add(motorizacao);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}