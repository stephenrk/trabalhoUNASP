//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recarga
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public System.DateTime Data { get; set; }
        public int OperadoraId { get; set; }
        public int TelefoneId { get; set; }
        public int FormaPagId { get; set; }
    
        public virtual FormaPagamento FormaPagamento { get; set; }
        public virtual Operadora Operadora { get; set; }
        public virtual Telefone Telefone { get; set; }
    }
}
