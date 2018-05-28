namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reuniao")]
    public partial class Reuniao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reuniao()
        {
            ConfirmacaoReuniao = new HashSet<ConfirmacaoReuniao>();
        }

        [Key]
        public int id_reuniao { get; set; }

        public int fk_proposta { get; set; }

        [StringLength(100)]
        public string texto_adicional { get; set; }

        [Required]
        [StringLength(128)]
        public string fk_login { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConfirmacaoReuniao> ConfirmacaoReuniao { get; set; }

        public virtual Proposta Proposta { get; set; }

        public virtual User User { get; set; }
    }
}
