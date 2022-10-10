using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZaFirmu.Data
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public int brIndeksa { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Godina { get; set; }

        [ForeignKey("IdStatusa")]
        public int IDStatusa { get; set; }

    }
}


