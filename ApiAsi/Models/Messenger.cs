namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Messenger")]
    public partial class Messenger
    {
        [Key]
        public int id_messsenger { get; set; }

        public int fk_proposta { get; set; }

        public virtual Proposta Proposta { get; set; }
    }
}
