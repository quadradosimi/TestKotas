using Microsoft.EntityFrameworkCore;

namespace TestKotas.Model
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Sprite { get; set; }
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public bool IsDefault { get; set; }
        public string LocationAreaEncounters { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }
        public List<Evolution> Evolutions { get; set; }

    }
}


