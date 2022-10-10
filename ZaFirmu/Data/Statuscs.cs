using System.ComponentModel.DataAnnotations;

namespace ZaFirmu.Data
{
    public class Statuscs
    {
        [Key]
        public int StutusStudenta { get; set; }

        public string NazivStatusa { get; set; }
    }
}
