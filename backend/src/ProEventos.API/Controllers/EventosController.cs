using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Persistence.Contextos;
using ProEventos.Domain;
using ProEventos.Application.Contratos;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{

  private readonly IEventosService _eventoService;

  public EventosController(IEventosService eventoService)
  {
    _eventoService = eventoService;


  }


  [HttpGet]
  public async Task<IActionResult> Get()
  {
    try
    {
      var eventos = await _eventoService.GetAllEventosAsync(true);
      if (eventos == null) return NotFound("Nenhum Evento encontrado.");

      return Ok(eventos);
    }
    catch (Exception ex)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError,
      $"Erro ao tentar recuperar Eventos. Erro :{ex.Message}");
    }

  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    try
    {
      var evento = await _eventoService.GetEventoByIdAsync(id, true);
      if (evento == null) return NotFound("Evento por ID não encontrado.");

      return Ok(evento);
    }
    catch (Exception ex)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError,
      $"Erro ao tentar recuperar Eventos. Erro :{ex.Message}");
    }
  }

  [HttpGet("{tema}/tema")]
  public async Task<IActionResult> GetByTema(string tema)
  {
    try
    {
      var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
      if (evento == null) return NotFound("Eventos por Tema não encontrado.");

      return Ok(evento);
    }
    catch (Exception ex)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError,
      $"Erro ao tentar recuperar Eventos. Erro :{ex.Message}");
    }
  }


  [HttpPost]
  public async Task<IActionResult> Post(Evento model)
  {
    try
    {
      var evento = await _eventoService.AddEventos(model);
      if (evento == null) return BadRequest("Erro ao tentar Adicionar Evento.");

      return Ok(evento);
    }
    catch (Exception ex)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError,
      $"Erro ao tentar adicionar Eventos. Erro :{ex.Message}");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, Evento model)
  {
    try
    {
      var evento = await _eventoService.UpdateEvento(id, model);
      if (evento == null) return BadRequest("Erro ao tentar Alterar Evento.");

      return Ok(evento);
    }
    catch (Exception ex)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError,
      $"Erro ao tentar atualizar Eventos. Erro :{ex.Message}");
    }
  }


  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      return await _eventoService.DeleteEvento(id) ?
         Ok("Evento Excluido.") :
         BadRequest("Evento não Excluido.");
    }
    catch (Exception ex)
    {

      return this.StatusCode(StatusCodes.Status500InternalServerError,
      $"Erro ao tentar deletar Eventos. Erro :{ex.Message}");
    }
  }

}
