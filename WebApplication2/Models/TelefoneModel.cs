using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication2.EF;

namespace WebApplication2.Models
{
    public class TelefoneModel
    {
        public TelefoneModel()
        {
            this.Telefones = new List<Telefone>();
        }

        public int Id { get; set; }

        public string Numero { get; set; }

        public int OperadoraId { get; set; }

        public SelectList Operadoras { get; set; }

        public IList<Telefone> Telefones { get; set; }
    }
}