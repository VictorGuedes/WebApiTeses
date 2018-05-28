namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConfirmacaoReuniao")]
    public partial class ConfirmacaoReuniao
    {
        [Key]
        public int id_confirmacao { get; set; }

        public int fk_reuniao { get; set; }

        [Required]
        [StringLength(128)]
        public string fk_user { get; set; }

        public virtual Reuniao Reuniao { get; set; }

        public virtual User User { get; set; }
    }
}
