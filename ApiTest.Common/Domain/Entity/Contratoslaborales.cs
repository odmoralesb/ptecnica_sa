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
    [Table("contratoslaborales")]
    public partial class Contratoslaborales : EntityBase
    {
        public Contratoslaborales()
        {
            Novedadesnomina = new HashSet<Novedadesnomina>();
        }

        [Key]
        [Column("idcontrato")]
        public int Idcontrato { get; set; }
        [Column("idestado")]
        public int? Idestado { get; set; }
        [Column("idarl")]
        public int? Idarl { get; set; }
        [Column("idcargo")]
        public int? Idcargo { get; set; }
        [Column("idtipodocumento")]
        public int? Idtipodocumento { get; set; }
        [Column("numerodocumento", TypeName = "numeric(16,0)")]
        public decimal? Numerodocumento { get; set; }
        [Column("primerapellido")]
        [StringLength(20)]
        public string Primerapellido { get; set; }
        [Column("segundoapellido")]
        [StringLength(20)]
        public string Segundoapellido { get; set; }
        [Column("primernombre")]
        [StringLength(20)]
        public string Primernombre { get; set; }
        [Column("segundonombre")]
        [StringLength(20)]
        public string Segundonombre { get; set; }
        [Column("fechainicio", TypeName = "date")]
        public DateTime? Fechainicio { get; set; }
        [Column("fechafin", TypeName = "date")]
        public DateTime? Fechafin { get; set; }
        [Column("salario", TypeName = "numeric(12,0)")]
        public decimal? Salario { get; set; }
        [Column("usuariocreacion")]
        [StringLength(20)]
        public string Usuariocreacion { get; set; }
        [Column("fechacreacion")]
        public DateTime? Fechacreacion { get; set; }

        [ForeignKey(nameof(Idarl))]
        [InverseProperty(nameof(Arl.Contratoslaborales))]
        public virtual Arl IdarlNavigation { get; set; }
        [ForeignKey(nameof(Idcargo))]
        [InverseProperty(nameof(Cargos.Contratoslaborales))]
        public virtual Cargos IdcargoNavigation { get; set; }
        [ForeignKey(nameof(Idestado))]
        [InverseProperty(nameof(Estados.Contratoslaborales))]
        public virtual Estados IdestadoNavigation { get; set; }
        [ForeignKey(nameof(Idtipodocumento))]
        [InverseProperty(nameof(Tipodocumento.Contratoslaborales))]
        public virtual Tipodocumento IdtipodocumentoNavigation { get; set; }
        [InverseProperty("IdcontratoNavigation")]
        public virtual ICollection<Novedadesnomina> Novedadesnomina { get; set; }
    }
}
