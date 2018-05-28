namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnexoRevisaoRelatorio")]
    public partial class AnexoRevisaoRelatorio
    {
        [Key]
        public int id_anexorevisaorelatorio { get; set; }

        [Required]
        [StringLength(25)]
        public string path { get; set; }

        public int fk_revisao_relatorio { get; set; }

        public virtual RevisaoRelatorio RevisaoRelatorio { get; set; }
    }
}
