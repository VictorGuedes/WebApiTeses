namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Departamento")]
    public partial class Departamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departamento()
        {
            Professor = new HashSet<Professor>();
        }

        [Key]
        public int id_departamento { get; set; }

        [Required]
        [StringLength(25)]
        public string nome { get; set; }

        public int fk_escola { get; set; }

        [StringLength(10)]
        public string sinc_code_ext { get; set; }

        public virtual Escola Escola { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professor> Professor { get; set; }
    }
}
