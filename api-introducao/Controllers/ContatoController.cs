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

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _dbcontext.Add(contato);
            _dbcontext.SaveChanges();
            return Ok(contato);
        }
    }
}