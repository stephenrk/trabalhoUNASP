using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebApplication2.EF;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly DB_RECARGAEntities entity = new DB_RECARGAEntities();

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
            if (operadora.Id <= 0)
            {
                entity.Operadora.Add(operadora);
            }
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
            if (formaPagamento.Id <= 0)
            {
                entity.FormaPagamento.Add(formaPagamento);
            }
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
            var telefone = entity.Telefone.Where(x => x.Id == id).FirstOrDefault();

            var operadoras = entity.Operadora.ToList();

            TelefoneModel telefoneModel = new TelefoneModel
            {
                Id = telefone.Id,
                Numero = telefone.Numero,
                OperadoraId = telefone.OperadoraId,
                Telefones = entity.Telefone.ToList(),
                Operadoras = new SelectList(operadoras, "Id", "Nome")
            };

            return View("ListaTelefones", telefoneModel);
        }

        public ActionResult IncluirTelefone(TelefoneModel telefoneModel)
        {
            Telefone telefone = new Telefone
            {
                Id = telefoneModel.Id,
                Numero = telefoneModel.Numero,
                OperadoraId = telefoneModel.OperadoraId
            };

            if (telefone.Id <= 0)
            {
                entity.Telefone.Add(telefone);
            }
            else
            {
                entity.Entry(telefone).State = EntityState.Modified;
            }
            entity.SaveChanges();

            return RedirectToAction("ListaTelefones");
        }

        public ActionResult ListaTelefones()
        {
            TelefoneModel telefoneModel = new TelefoneModel();
            var operadoras = entity.Operadora.ToList();
            telefoneModel.Telefones = entity.Telefone.ToList();

            telefoneModel.Operadoras = new SelectList(operadoras, "Id", "Nome");

            return View(telefoneModel);
        }

        public ActionResult Index()
        {
            var recargaModel = new RecargaModel();

            var telefones = entity.Telefone.ToList();
            var formasPagamento = entity.FormaPagamento.ToList();

            recargaModel.Telefones = new SelectList(telefones, "Id", "Numero");
            recargaModel.FormasPagamento = new SelectList(formasPagamento, "Id", "Descricao");
            recargaModel.Recargas = entity.Recarga.ToList();
            ViewBag.total = recargaModel.Recargas.Count();

            return View(recargaModel);
        }

        public ActionResult IncluirRecarga(RecargaModel recargaModel)
        {
            Recarga recarga = new Recarga
            {
                Id = recargaModel.Id,
                TelefoneId = recargaModel.TelefoneId,
                FormaPagId = recargaModel.FormaPagId,
                Data = DateTime.Now,
                Valor = recargaModel.Valor
            };


            if (recarga.Id <= 0)
            {
                entity.Recarga.Add(recarga);
            }
            else
            {
                entity.Entry(recarga).State = EntityState.Modified;
            }
            entity.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}