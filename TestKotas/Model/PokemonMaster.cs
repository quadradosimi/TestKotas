using Microsoft.EntityFrameworkCore;

namespace TestKotas.Model
{
    public class PokemonMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDay { get; set; }

    }
}
