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
    [Table("novedadesnomina")]
    public partial class Novedadesnomina : EntityBase
    {
        [Key]
        [Column("idnovedadnomina")]
        public int Idnovedadnomina { get; set; }
        [Column("idcontrato")]
        public int? Idcontrato { get; set; }
        [Column("periodolaborado")]
        [StringLength(20)]
        public string Periodolaborado { get; set; }
        [Column("horaslaboradas", TypeName = "numeric(4,0)")]
        public decimal? Horaslaboradas { get; set; }
        [Column("horaextradiurna", TypeName = "numeric(12,0)")]
        public decimal? Horaextradiurna { get; set; }
        [Column("horaextranocturna", TypeName = "numeric(12,0)")]
        public decimal? Horaextranocturna { get; set; }
        [Column("horaextradominical", TypeName = "numeric(12,0)")]
        public decimal? Horaextradominical { get; set; }
        [Column("horaextrafestiva", TypeName = "numeric(12,0)")]
        public decimal? Horaextrafestiva { get; set; }
        [Column("descuentos", TypeName = "numeric(12,0)")]
        public decimal? Descuentos { get; set; }
        [Column("usuariocreacion")]
        [StringLength(20)]
        public string Usuariocreacion { get; set; }
        [Column("fechacreacion")]
        public DateTime? Fechacreacion { get; set; }

        [ForeignKey(nameof(Idcontrato))]
        [InverseProperty(nameof(Contratoslaborales.Novedadesnomina))]
        public virtual Contratoslaborales IdcontratoNavigation { get; set; }
    }
}
