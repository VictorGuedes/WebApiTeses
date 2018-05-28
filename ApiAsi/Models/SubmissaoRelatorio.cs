namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubmissaoRelatorio")]
    public partial class SubmissaoRelatorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubmissaoRelatorio()
        {
            AnexoSubmissaoRelatorio = new HashSet<AnexoSubmissaoRelatorio>();
            RevisaoRelatorio = new HashSet<RevisaoRelatorio>();
        }

        [Key]
        public int id_submissao { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_submissao { get; set; }

        [Required]
        [StringLength(128)]
        public string fk_user_criador { get; set; }

        public int fk_proposta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnexoSubmissaoRelatorio> AnexoSubmissaoRelatorio { get; set; }

        public virtual Proposta Proposta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RevisaoRelatorio> RevisaoRelatorio { get; set; }

        public virtual User User { get; set; }
    }
}
