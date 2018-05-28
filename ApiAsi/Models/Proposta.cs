namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proposta")]
    public partial class Proposta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proposta()
        {
            Messenger = new HashSet<Messenger>();
            Reuniao = new HashSet<Reuniao>();
            SubmissaoRelatorio = new HashSet<SubmissaoRelatorio>();
        }

        public int fk_propostasubmetida { get; set; }

        [Required]
        [StringLength(10)]
        public string fk_aluno { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_atribuicao { get; set; }

        [Key]
        public int id_proposta { get; set; }

        public virtual Aluno Aluno { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Messenger> Messenger { get; set; }

        public virtual PropostaSubmetida PropostaSubmetida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reuniao> Reuniao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubmissaoRelatorio> SubmissaoRelatorio { get; set; }
    }
}
