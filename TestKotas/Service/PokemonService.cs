using TestKotas.Entity;
using TestKotas.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization.Json;
using System.Text;

namespace TestKotas.Service
{
    public class PokemonService : IPokemonService
    {
        private readonly ApplicationDbContext _db;
        public PokemonService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Pokemon>> GetCapturedPokemons()
        {

            var pokemonNames = await _db.PokemonCaptured.ToListAsync();

            List<Pokemon> pokemons = new List<Pokemon>();

            foreach (var pokemonName in pokemonNames)
            {
                //get full pokemon data from external API with pokemon name
                var pokemonFull = await GetPokemonByID(pokemonName.Name);

                pokemons.Add(pokemonFull);
            }

            return pokemons;
        }

        public async Task<Pokemon?> GetPokemonByID(string pokemonName)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/{pokemonName}";
            //call API get values from Pokemon
            var allData = await GetData(url);

            //not find the pokemon in external API
            if (allData == "Not Found")
            {
                return null;
            }
            //convert data to responde model Pokemon
            return await ConvertExternalDataToPokemonModel(allData);
        }

        public async Task<bool> ValidatePokemonExistByID(string pokemonName)
        {
            return await GetPokemonByID(pokemonName) != null ? true : false;
        }

        public async Task<List<Pokemon>> GetPokemons()
        {
            var rnd = new Random();
            var offSet = rnd.Next(0, 1000);

            var url = $"https://pokeapi.co/api/v2/pokemon?limit=10&offset={offSet}";
            //call API get values from Pokemon
            var allData = await GetData(url);
            //convert data to responde model Pokemon
            return await GetPokemonsDetails(allData);
        }

        public async Task<PokemonCaptured?> AddPokemonCaptured(PokemonCaptured pokemon)
        {
            if (await ValidatePokemonExistByID(pokemon.Name))
            {
                _db.PokemonCaptured.Add(pokemon);
                var result = await _db.SaveChangesAsync();
                return result >= 0 ? pokemon : null;
            }
            else
            {
                return null;
            }
        }
        public async Task<PokemonMaster?> AddPokemonMaster(PokemonMaster pokemonMaster)
        {
            _db.PokemonMaster.Add(pokemonMaster);
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? pokemonMaster : null;
        }
        private async Task<string> GetData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                var content = response.Content.ReadAsStringAsync();
                return content.Result;
            }
        }

        private async Task<List<Pokemon>> GetPokemonsDetails(string data)
        {
            //data = data.Replace("type", "evolution");
            var serializer = new DataContractJsonSerializer(typeof(ExternalDataPokemonsNames));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(data));
            var obj = (ExternalDataPokemonsNames)serializer.ReadObject(ms);

            List<Pokemon> pokemons = new List<Pokemon>();

            List<BasicType> pokemonNames = obj.results.ToList();

            foreach (var pokemonName in pokemonNames)
            {
                //get full pokemon data from external API with pokemon name
                var pokemonFull = await GetPokemonByID(pokemonName.name);

                pokemons.Add(pokemonFull);
            }

            return pokemons;
        }
        private async Task<Pokemon> ConvertExternalDataToPokemonModel(string data)
        {
            data = data.Replace("type", "evolution");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ExternalData));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));
            ExternalData obj = (ExternalData)serializer.ReadObject(ms);

            Pokemon pokemon = new Pokemon();

            //get sprites
            pokemon.Sprite = obj.sprites.front_default;//"front_default"

            ////set basic data
            pokemon.BaseExperience = obj.base_experience;
            pokemon.Height = obj.height;
            pokemon.IsDefault = obj.is_default;
            pokemon.LocationAreaEncounters = obj.location_area_encounters;
            pokemon.Name = obj.name;
            pokemon.Order = obj.order;
            pokemon.Weight = obj.weight;


            List <Evolution> evolutions = obj.evolutions.ToList();
            List<Evolution> teste = new List<Evolution>(); ;

            foreach (var evolution in evolutions)
            {
                var pokemonEvolution = new Evolution();

                pokemonEvolution.slot = evolution.slot;
                pokemonEvolution.evolution = new BasicType();
                pokemonEvolution.evolution.url = evolution.evolution.url;
                pokemonEvolution.evolution.name = evolution.evolution.name;

                teste.Add(pokemonEvolution);
            }

            pokemon.Evolutions = teste;


            return pokemon;
        }
    }
}
