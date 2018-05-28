namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InstituicaoEnsino")]
    public partial class InstituicaoEnsino
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InstituicaoEnsino()
        {
            Escola = new HashSet<Escola>();
        }

        [Key]
        public int id_instituto { get; set; }

        [Required]
        [StringLength(25)]
        public string name { get; set; }

        [StringLength(10)]
        public string sinc_code_ext { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Escola> Escola { get; set; }
    }
}
