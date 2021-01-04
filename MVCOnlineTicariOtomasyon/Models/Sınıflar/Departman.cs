using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }

        [Display(Name ="Departman Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmanAD { get; set; }
        public bool Durum { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}