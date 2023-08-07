using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
  public IEnumerable<Evento> _evento = new Evento[]
  {

  };

  public readonly DataContext _context;

  public EventosController(DataContext context)
  {
    _context = context;

  }


  [HttpGet]
  public IEnumerable<Evento> Get()
  {
    return _context.Eventos;

  }

  [HttpGet("{id}")]
  public Evento GetById(int id)
  {
    return _context.Eventos.FirstOrDefault(
      evento => evento.EventoId == id
    );
  }


  [HttpPost]
  public string Post()
  {
    return "Exemplo POST";
  }

  [HttpPut("{id}")]
  public string Put(int id)
  {
    return $"Exemplo PUT com id = {id}";
  }

  [HttpDelete("{id}")]
  public string Delete(int id)
  {
    return $"Exemplo DELETE com id = {id}";
  }

}
