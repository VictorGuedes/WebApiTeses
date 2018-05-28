namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnexoSubmissaoRelatorio")]
    public partial class AnexoSubmissaoRelatorio
    {
        [Key]
        public int id_anexosubmissaorelatorio { get; set; }

        [Required]
        [StringLength(25)]
        public string path { get; set; }

        public int fk_submissaorelatorio { get; set; }

        public virtual SubmissaoRelatorio SubmissaoRelatorio { get; set; }
    }
}
