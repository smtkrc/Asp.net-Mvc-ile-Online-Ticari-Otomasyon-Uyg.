using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Gider
    {
        [Key]
        public int DepartmanID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string DepartmanAD { get; set; }
        public int GiderID { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public Decimal Tutar { get; set; }
    }
}