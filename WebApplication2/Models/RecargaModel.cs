using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication2.EF;

namespace WebApplication2.Models
{
    public class RecargaModel
    {
        public RecargaModel()
        {
            this.Recargas = new List<Recarga>();
        }

        public int Id { get; set; }

        public int TelefoneId { get; set; }

        public int FormaPagId { get; set; }

        public decimal Valor { get; set; }

        public SelectList Telefones { get; set; }

        public IList<Recarga> Recargas { get; set; }

        public SelectList FormasPagamento { get; set; }
    }
}