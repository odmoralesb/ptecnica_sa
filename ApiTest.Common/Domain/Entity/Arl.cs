using ApiTest.Common.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiTest.Common.Domain.Entity
{
    [Table("arl")]
    public partial class Arl : EntityBase
    {
        public Arl()
        {
            Contratoslaborales = new HashSet<Contratoslaborales>();
        }

        [Key]
        [Column("idarl")]
        public int Idarl { get; set; }
        [Column("valor", TypeName = "numeric(6,0)")]
        public decimal? Valor { get; set; }
        [Column("usuariocreacion")]
        [StringLength(20)]
        public string Usuariocreacion { get; set; }
        [Column("fechacreacion")]
        public DateTime? Fechacreacion { get; set; }
        [Column("habilitado")]
        public bool? Habilitado { get; set; }

        [InverseProperty("IdarlNavigation")]
        public virtual ICollection<Contratoslaborales> Contratoslaborales { get; set; }
    }
}
