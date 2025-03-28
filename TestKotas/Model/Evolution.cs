using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System.IO;

namespace TestKotas.Model
{
    public class Evolution
    {
        public BasicType evolution { get; set; }
        public int slot { get; set; }
    }
}
