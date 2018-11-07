using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.EF;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly RA76154Entities entity = new RA76154Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListaOperadoras()
        {
            ViewBag.Operadoras = entity.Operadora;

            return View();
        }

        public ActionResult RemoverOperadora(int id)
        {
            var operadora = entity.Operadora.Where(x => x.Id == id).FirstOrDefault();
            entity.Operadora.Remove(operadora);
            entity.SaveChanges();

            return RedirectToAction("ListaOperadoras");
        }

        public ActionResult AlterarOperadora(int id)
        {
            ViewBag.Operadoras = entity.Operadora;
            var operadora = entity.Operadora.Where(x => x.Id == id).FirstOrDefault();

            return View("ListaOperadoras", operadora);
        }

        public ActionResult IncluirOperadora(Operadora operadora)
        {
            // No id so we add it to database
            if (operadora.Id <= 0)
            {
                entity.Operadora.Add(operadora);
            }
            // Has Id, therefore it's in database so we update
            else
            {
                entity.Entry(operadora).State = EntityState.Modified;
            }
            entity.SaveChanges();

            return RedirectToAction("ListaOperadoras");
        }

        public ActionResult AlterarFormaPagamento(int id)
        {
            ViewBag.FormasPagamento = entity.FormaPagamento;
            var formaPagamento = entity.FormaPagamento.Where(x => x.Id == id).FirstOrDefault();

            return View("ListaFormaPagamentos", formaPagamento);
        }

        public ActionResult IncluirFormaPagamento(FormaPagamento formaPagamento)
        {
            // No id so we add it to database
            if (formaPagamento.Id <= 0)
            {
                entity.FormaPagamento.Add(formaPagamento);
            }
            // Has Id, th+erefore it's in database so we update
            else
            {
                entity.Entry(formaPagamento).State = EntityState.Modified;
            }
            entity.SaveChanges();

            return RedirectToAction("ListaFormaPagamentos");
        }

        public ActionResult ListaFormaPagamentos()
        {
            ViewBag.FormasPagamento = entity.FormaPagamento;

            return View();
        }

        public ActionResult AlterarTelefone(int id)
        {
            ViewBag.Telefones = entity.Telefone;
            var telefone = entity.Telefone.Where(x => x.Id == id).FirstOrDefault();

            return View("ListaTelefones", telefone);
        }

        public ActionResult IncluirTelefone(Telefone telefone)
        {
            // No id so we add it to database
            if (telefone.Id <= 0)
            {
                entity.Telefone.Add(telefone);
            }
            // Has Id, th+erefore it's in database so we update
            else
            {
                entity.Entry(telefone).State = EntityState.Modified;
            }
            entity.SaveChanges();

            return RedirectToAction("ListaTelefones");
        }

        public ActionResult ListaTelefones()
        {
            ViewBag.Telefones = entity.Telefone;

            return View();
        }

        public ActionResult Recarga()
        {
            var recarga = new Recarga();

            var telefones = (IEnumerable<Telefone>) entity.Telefone;

            recarga.Telefone = new SelectList(telefones, "Id", "Numero");

            ViewBag.Telefones = entity.Telefone;

            return View();
        }

        
    }
}