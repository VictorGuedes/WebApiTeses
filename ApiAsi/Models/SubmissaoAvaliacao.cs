namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubmissaoAvaliacao")]
    public partial class SubmissaoAvaliacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubmissaoAvaliacao()
        {
            AnexoAvaliacao = new HashSet<AnexoAvaliacao>();
        }

        [Key]
        public int id_submissao { get; set; }

        [Required]
        [StringLength(128)]
        public string fk_user_criador { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_submissao { get; set; }

        [StringLength(50)]
        public string descricao { get; set; }

        public int fk_avaliacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnexoAvaliacao> AnexoAvaliacao { get; set; }

        public virtual Avaliacao Avaliacao { get; set; }

        public virtual User User { get; set; }
    }
}
