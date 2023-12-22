using System.Runtime.InteropServices.JavaScript;
using System.Security.Policy;
using System.ComponentModel.DataAnnotations;

namespace fussball.Models
{
    public class Kamp
    {
        public int Id { get; set; }

        [Display(Name = "Kampdato")]
        [DataType(DataType.Date)]
        public DateTime Dato { get; set; }

        public int ScoreLag1 { get; set; }
        public int ScoreLag2 { get; set; }


        //public virtual Kampspiller KampSpiller { get; set; }

    }
}
