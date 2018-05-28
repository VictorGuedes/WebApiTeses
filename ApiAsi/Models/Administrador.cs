namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrador")]
    public partial class Administrador
    {
        [Key]
        public int id_admin { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(25)]
        public string cv { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_nascimento { get; set; }

        [Required]
        [StringLength(128)]
        public string fk_user { get; set; }

        public virtual User User { get; set; }
    }
}
