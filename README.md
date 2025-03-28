# React + .NET 8

## TEST Kotas

Essa API faz o GET de dados sobre Pokemons em uma API externa e trata esses dados para devolv�-los. Tamb�m � poss�vel
cadastrar mestres pokemons e os pokemons que foram capturados.  No caso dos Pokemons capturados tamb�m � poss�vel ver uma lista de todos eles.

Para rodar a aplica��o � necess�rio fazer o download do projeto no GitHub

	https://github.com/quadradosimi/Kotas

Rodar Back-end
	
	Abra o projeto .Net no arquivo TestKotas.sln. No arquivo appsettings.json mude as configura��es do ConnectionStrings com os dados de sua base de dados.
	Rode a migration para criar a base de dados e as tabelas usando o codigo abaixo:

		add-migration [name]
		
	e depois use

		update-database
		
	Escolha https no Visual Studio para rodar a API. O swagger ir� aparecer.

Documenta��o das tarefas e passos exexutados para finalizar do projeto

	Tarefas:

		- (ok) API .NET CORE 8
 
			- C:\Users\Lenovo\Documents\TesteKotas\TestKotas\TestKotas\TestKotas.sln
	
		- (ok) testes

			 //GetByID para 1 Pok�mon espec�fico
			 //Get para 10 Pok�mon aleat�rios
			 //Listagem dos Pok�mon j� capturados.
			 //Post para informar que um Pok�mon foi capturado.
			 //Post Cadastro do mestre pokemon
	 
		- (ok) fazer JWT e colocar [Authorize] controles de novo
		- (ok) EntityFramework para SQLite

			- Microsoft.EntityFrameworkCore.Sqlite
	
		- (ok) readme

 
		 - (ok) endpoints
 
				pokemon/ditto, pokemon-species/aegislash, type/3, ability/battle-armor, or pokemon?limit=100000&offset=0.(da API externa)
 
			- (ok) Get para 10 Pok�mon aleat�rios
	
				- usa pokemon?limit=10&offset=0 alterando dinamicamente o valor do offset at� 1000
					- com nome do pokemon pega dados espec�ficos (https://pokeapi.co/api/v2/pokemon/wo-chien)(GetByID)
		
			- (ok) GetByID para 1 Pok�mon espec�fico
	
				- https://pokeapi.co/api/v2/pokemon/wo-chien colocar nome pokemon que quer achar
		
				- (ok) converter objeto resposta da API origem em padr�o de resposta da API local

				- (ok) ser� reutilizado como padr�o em todas respostas dos outros endepoints
		
			- (ok) Cadastro do mestre pokemon (dados b�sicos como nome, idade e cpf) em SQLite
	
				- usar EntityFramework
				- nova tabela MestrePokemon (id, nome, idade e cpf)
		
			- (ok) Post para informar que um Pok�mon foi capturado.

				- usar EntityFramework
				- validar se nome existe na base origem
				- nova tabela PokemonCapturado (id, nome pokemon)
		
			- (ok) Listagem dos Pok�mon j� capturados.
	
				- usar EntityFramework
				- get tabela nova PokemonCapturado

		- (ok) Requisitos

			1 - Todos os endpoints devem retornar os dados b�sicos do Pok�mon, suas evolu��es e o base64 de sprite default de cada Pok�mon. (usar em GetByID para 1 Pok�mon espec�fico)
	
				- base64 de sprite default de cada Pok�mon
		
					"sprites": {
								 "front_default": "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1001.png"
							   }
				
				- evolu��es 
		
					 "types": [
								{
								  "slot": 1,
								  "type": {
									"name": "dark",
									"url": "https://pokeapi.co/api/v2/type/17/"
								  }
								},
								{
								  "slot": 2,
								  "type": {
									"name": "grass",
									"url": "https://pokeapi.co/api/v2/type/12/"
								  }
								}
						
				- dados b�sicos do Pok�mon
		
					- "base_experience": 285,
					- "height": 15,
					- "id": 1001,
					- "is_default": true,
					- "location_area_encounters": "https://pokeapi.co/api/v2/pokemon/1001/encounters",
					- "name": "wo-chien",
					- "order": 996,
					- "weight": 742
				
		- (ok) desenhar models aplica��o		

						- quais model?
				
							- (ok) model getId (pokemon)
							- (ok) model mestrePokemon
							- (ok) model pokemonCapturado 

Arquitetura da API Restfull

	arquitetura de software
				
		- Arquitetura Monolitica
		- Arquitetura em Camadas
					
	arquitetura de c�digo
				
		- uso de DDD 
		- TDD
		- Clean-Code
		- Solid Principles
		- Contar com pipelines automatizadas de CI/CD Pipelines (Continuous Integration/Continuous Delivery) usando por exemplo SonarCube e GitActions

	

	
			
