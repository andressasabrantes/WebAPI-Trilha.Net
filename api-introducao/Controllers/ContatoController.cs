using api_introducao.Models;
using api_introducao.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api_introducao.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaRepository _dbcontext;

        public ContatoController(AgendaRepository dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost("CriarContato")]
        public IActionResult Create(Contato contato)
        {
            _dbcontext.Add(contato);
            _dbcontext.SaveChanges();
            return Ok(contato);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _dbcontext.Contatos.Find(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }
    }
}