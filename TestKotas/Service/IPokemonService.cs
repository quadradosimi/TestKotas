using TestKotas.Model;

namespace TestKotas.Service
{
    public interface IPokemonService
    {
        //Listagem dos Pokémon já capturados.
        Task<List<Pokemon>> GetCapturedPokemons();

        ////Get para 10 Pokémon aleatórios
        Task<List<Pokemon>> GetPokemons();

        //GetByID para 1 Pokémon específico
        Task<Pokemon?> GetPokemonByID(string id);

        //Post para informar que um Pokémon foi capturado.
        Task<PokemonCaptured?> AddPokemonCaptured(PokemonCaptured obj);

        //Post Cadastro do mestre pokemon
        Task<PokemonMaster> AddPokemonMaster(PokemonMaster obj);


    }
}
