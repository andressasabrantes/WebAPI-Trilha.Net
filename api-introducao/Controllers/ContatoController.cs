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
            return CreatedAtAction(nameof(ObterPorId), new { id = contato.Id }, contato);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _dbcontext.Contatos.Find(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _dbcontext.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);             
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _dbcontext.Contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _dbcontext.Contatos.Update(contatoBanco);
            _dbcontext.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _dbcontext.Contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();

            _dbcontext.Contatos.Remove(contatoBanco);
            _dbcontext.SaveChanges();

            return NoContent();
        }
    }
}