using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.Models
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        public String Ad { get; set; }
        public String Soyad { get; set; }
        public String Sehir { get; set; }

        public int BirimID { get; set; }
        public Birim Birim { get; set; }
    }
}
