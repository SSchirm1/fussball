using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace fussball.Models
{
    public class Kampspiller
    {
        public int Id { get; set; }

        [ForeignKey("Kamp")]
        public int KampId { get; set; }
        public int spillerId { get; set; }


        public bool Lag1 { get; set; }

        //public virtual Kamp Kamp { get; set; }

    }
}
