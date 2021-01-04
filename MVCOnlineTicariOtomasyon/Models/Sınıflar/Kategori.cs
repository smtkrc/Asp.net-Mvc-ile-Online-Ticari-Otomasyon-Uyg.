using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Kategori
    {
        [Key]
        public int KATEGORIID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KATEGORIAD { get; set; }
        public ICollection<Urun> Uruns { get; set; }
    }
}