namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mensagem")]
    public partial class Mensagem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mensagem()
        {
            AnexoMensagem = new HashSet<AnexoMensagem>();
        }

        [Key]
        public int id_mensagem { get; set; }

        public DateTime data_receive { get; set; }

        public int fk_messenger { get; set; }

        [Column("mensagem")]
        [Required]
        [StringLength(1500)]
        public string mensagem1 { get; set; }

        [Required]
        [StringLength(128)]
        public string fk_user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnexoMensagem> AnexoMensagem { get; set; }

        public virtual User User { get; set; }
    }
}
