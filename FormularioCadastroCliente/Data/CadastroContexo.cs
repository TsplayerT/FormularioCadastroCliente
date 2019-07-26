using FormularioCadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace FormularioCadastroCliente.Data
{
    public class CadastroContexo : DbContext
    {
        public CadastroContexo(DbContextOptions<CadastroContexo> opcao) : base(opcao)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
