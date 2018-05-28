namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnexoAvaliacao")]
    public partial class AnexoAvaliacao
    {
        [Key]
        public int id_anexo { get; set; }

        [Required]
        [StringLength(20)]
        public string path_anexo { get; set; }

        public int fk_submissao { get; set; }

        public virtual SubmissaoAvaliacao SubmissaoAvaliacao { get; set; }
    }
}
