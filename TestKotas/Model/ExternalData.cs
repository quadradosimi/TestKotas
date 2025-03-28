using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TestKotas.Model
{
    public class ExternalData
    {
        //public string Sprite { get; set; }
        public int base_experience { get; set; }
        public int height { get; set; }
        public bool is_default { get; set; }
        public string location_area_encounters { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public int weight { get; set; }
        public Evolution[] evolutions { get; set; }
        public Sprite sprites { get; set; }


    }
}


