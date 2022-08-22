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
    public class VeiculosController : Controller
    {
        private EFContext context = new EFContext();
        public ActionResult Index()
        {
            return View(
                context.Veiculos.OrderBy(c => c.Modelo)
                );
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MotorizacaoId = new SelectList(context.Motorizacaos.OrderBy(b => b.Modelo),
            "MotorizacaoId", "Modelo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veiculo veiculo)
        {
            context.Veiculos.Add(veiculo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = context.Veiculos.Where(f => f.VeiculoId == id).
            Include("Veiculos").First();
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }
    }
}