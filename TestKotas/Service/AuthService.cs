using TestKotas.Entity;

namespace TestKotas.Service
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _db;
        public AuthService(ApplicationDbContext db)
        {
            _db = db;
        }

    }
}
