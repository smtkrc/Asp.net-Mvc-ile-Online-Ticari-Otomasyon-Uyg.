using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz!")]
        public string CariAD { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz!")]
        [Required(ErrorMessage ="Bu alanı boş geçemessiniz!")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50,ErrorMessage ="En fazla 50 karakter yazabilirsiniz!")]
        public string CariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "En fazla 50 karakter yazabilirsiniz!")]
        public string CariSifre { get; set; }

        public bool Durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}