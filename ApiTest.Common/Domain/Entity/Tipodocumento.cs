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
    [Table("tipodocumento")]
    public partial class Tipodocumento : EntityBase
    {
        public Tipodocumento()
        {
            Contratoslaborales = new HashSet<Contratoslaborales>();
        }

        [Key]
        [Column("idtipodocumento")]
        public int Idtipodocumento { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column("usuariocreacion")]
        [StringLength(20)]
        public string Usuariocreacion { get; set; }
        [Column("fechacreacion")]
        public DateTime? Fechacreacion { get; set; }

        [InverseProperty("IdtipodocumentoNavigation")]
        public virtual ICollection<Contratoslaborales> Contratoslaborales { get; set; }
    }
}
