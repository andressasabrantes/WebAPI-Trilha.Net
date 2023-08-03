using api_introducao.Models;
using Microsoft.EntityFrameworkCore;

namespace api_introducao.Repositories
{
    public class AgendaRepository : DbContext
    {
        public AgendaRepository(DbContextOptions<AgendaRepository> options) : base(options)
        {

        }

        public DbSet<Contato> Contatos { get; set; }
    }
}