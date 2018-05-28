namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Escola")]
    public partial class Escola
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Escola()
        {
            Departamento = new HashSet<Departamento>();
        }

        [Key]
        public int id_escola { get; set; }

        [Required]
        [StringLength(25)]
        public string nome { get; set; }

        public int fk_id_instituto { get; set; }

        [StringLength(10)]
        public string sinc_code_ext { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Departamento> Departamento { get; set; }

        public virtual InstituicaoEnsino InstituicaoEnsino { get; set; }
    }
}
