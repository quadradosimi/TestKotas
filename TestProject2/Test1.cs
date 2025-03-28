using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestKotas.Controllers;
using TestKotas.Entity;
using TestKotas.Model;
using TestKotas.Service;


namespace TestProject2
{
    [TestClass]
    public sealed class Test1
    {

        //GetByID para 1 Pokémon específico
        [TestMethod]
        public async Task GetPokemon()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<PokemonController>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Pokemons;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            PokemonService pokemonService = new PokemonService(context);

            PokemonController addPokemon = new PokemonController(pokemonService, logger);
            var result = await addPokemon.Get("wo-chien");

            Assert.IsNotNull(result);

         }

        //Get para 10 Pokémon aleatórios
        [TestMethod]
        public async Task GetPokemons()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<PokemonController>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Pokemons;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            PokemonService pokemonService = new PokemonService(context);

            PokemonController addPokemon = new PokemonController(pokemonService, logger);
            var result = await addPokemon.GetPokemons();

            Assert.IsNotNull(result);

        }
        //Listagem dos Pokémon já capturados.
        [TestMethod]
        public async Task GetCapturedPokemons()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<PokemonController>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Pokemons;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            PokemonService pokemonService = new PokemonService(context);

            PokemonController addPokemon = new PokemonController(pokemonService, logger);
            var result = await addPokemon.GetCapturedPokemons();

            Assert.IsNotNull(result);

        }
        //Post para informar que um Pokémon foi capturado.
        [TestMethod]
        public async Task PostCapturedPokemon()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<PokemonController>();

            PokemonCaptured pokemon = new PokemonCaptured();

            pokemon.Name = "wo-chien";
           
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Pokemons;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            PokemonService pokemonService = new PokemonService(context);

            PokemonController addPokemon = new PokemonController(pokemonService, logger);
            var result = await addPokemon.Post(pokemon);

            Assert.IsNotNull(result);

        }

        //Post Cadastro do mestre pokemon
        [TestMethod]
        public async Task PostPokemonMaster()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<PokemonController>();

            PokemonMaster pokemonMaster = new PokemonMaster();

            pokemonMaster.Name = "Teste";
            pokemonMaster.CPF = "03475375588";
            pokemonMaster.BirthDay = DateTime.Now.AddYears(-20);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Pokemons;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            PokemonService pokemonService = new PokemonService(context);

            PokemonController addPokemon = new PokemonController(pokemonService, logger);
            var result = await addPokemon.PostPokemonMaster(pokemonMaster);

            Assert.IsNotNull(result);

        }       
    }
}
