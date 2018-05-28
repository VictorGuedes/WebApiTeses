namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RevisaoRelatorio")]
    public partial class RevisaoRelatorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RevisaoRelatorio()
        {
            AnexoRevisaoRelatorio = new HashSet<AnexoRevisaoRelatorio>();
        }

        [Key]
        public int id_revisao_relatorio { get; set; }

        public int fk_submissaorelatorio { get; set; }

        [Required]
        [StringLength(128)]
        public string fk_user_criador { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_resposta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnexoRevisaoRelatorio> AnexoRevisaoRelatorio { get; set; }

        public virtual SubmissaoRelatorio SubmissaoRelatorio { get; set; }

        public virtual User User { get; set; }
    }
}
