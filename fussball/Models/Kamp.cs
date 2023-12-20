using System.Runtime.InteropServices.JavaScript;
using System.Security.Policy;

namespace fussball.Models
{
    public class Kamp
    {
        public int Id { get; set; }
        public DateTime Dato { get; set; }
        public List<Spiller> Lag1 { get; set; }
        public List<Spiller> Lag2 { get; set; }
    }
}
