namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnexoMensagem")]
    public partial class AnexoMensagem
    {
        [Key]
        public int id_anexo { get; set; }

        public int fk_mensagem { get; set; }

        [Required]
        [StringLength(50)]
        public string path_anexo { get; set; }

        public virtual Mensagem Mensagem { get; set; }
    }
}
