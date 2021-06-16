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
    [Table("cargos")]
    public partial class Cargos : EntityBase
    {
        public Cargos()
        {
            Contratoslaborales = new HashSet<Contratoslaborales>();
        }

        [Key]
        [Column("idcargo")]
        public int Idcargo { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column("usuariocreacion")]
        [StringLength(20)]
        public string Usuariocreacion { get; set; }
        [Column("fechacreacion")]
        public DateTime? Fechacreacion { get; set; }

        [InverseProperty("IdcargoNavigation")]
        public virtual ICollection<Contratoslaborales> Contratoslaborales { get; set; }
    }
}
