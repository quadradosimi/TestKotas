using TestKotas.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TestKotas.Model;

namespace TestKotas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;
    private readonly ILogger<PokemonController> _logger;
    public PokemonController(IPokemonService pokemonService, ILogger<PokemonController> logger)
    {
        _pokemonService = pokemonService;
        _logger = logger;
    }

    //GetByID para 1 Pokémon específico
    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> Get(string name)
    {
        var pokemon = await _pokemonService.GetPokemonByID(name);
        if (pokemon == null)
        {
            return NotFound();
        }
        return Ok(pokemon);
    }

    //Get para 10 Pokémon aleatórios
    [Route("/api/pokemons")]
    [HttpGet()]
    [Authorize]
    public async Task<IActionResult> GetPokemons()
    {

        var valide = await _pokemonService.GetPokemons();
        return Ok(valide);
    }

    //Listagem dos Pokémon já capturados.
    [Route("/api/captured-pokemons")]
    [HttpGet()]
    [Authorize]
    public async Task<IActionResult> GetCapturedPokemons()
    {

        var valide = await _pokemonService.GetCapturedPokemons();
        return Ok(valide);
    }

    //Post para informar que um Pokémon foi capturado.
    [Route("/api/captured-pokemons")]
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] PokemonCaptured pokemonCapturedObject)
    {
        var pokemon = await _pokemonService.AddPokemonCaptured(pokemonCapturedObject);

        if (pokemon == null)
        {
            return BadRequest();
        }

        return Ok(new
        {
            message = "Created Successfully!!!",
            id = pokemonCapturedObject!.Id
        });
    }

    //Post Cadastro do mestre pokemon
    [Route("/api/pokemon-master")]
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PostPokemonMaster([FromBody] PokemonMaster pokemonMasterObject)
    {
        var pokemonMaster = await _pokemonService.AddPokemonMaster(pokemonMasterObject);

        if (pokemonMaster == null)
        {
            return BadRequest();
        }

        return Ok(new
        {
            message = "Created Successfully!!!",
            id = pokemonMasterObject!.Id
        });
    }
}
