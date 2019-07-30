using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormularioCadastroCliente.Data;
using FormularioCadastroCliente.Models;

namespace FormularioCadastroCliente.Controllers
{
    public class HomeController : Controller
    {
        private CadastroContexo CadastroContexto { get; }

        public HomeController(CadastroContexo cadastroContexto)
        {
            CadastroContexto = cadastroContexto;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await CadastroContexto.Clientes.Where(x => x.Visivel).ToListAsync();

            return View(clientes);
        }

        public async Task<IActionResult> Visualizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await CadastroContexto.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View("VisualizarCliente", cliente);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View("CriarCliente");
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Cliente cliente)
        {
            cliente.Visivel = true;
            cliente.DataCriacao = DateTime.Now.ToString("dd/MM/yyyy");
            cliente.DataAlteracao = DateTime.Now.ToString("dd/MM/yyyy");

            CadastroContexto.Add(cliente);
            await CadastroContexto.SaveChangesAsync();

            return View("Index", await CadastroContexto.Clientes.ToListAsync());
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await CadastroContexto.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View("EditarCliente", cliente);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(int id, [Bind("Id,RazaoSocial,NomeFantasia,Cnpj,DataAberturaEmpresa,Endereco,Bairro,Cidade,Uf,Visivel,DataCriacao,DataAlteracao")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cliente.DataAlteracao = DateTime.Now.ToString("dd/MM/yyyy");

                    CadastroContexto.Update(cliente);
                    await CadastroContexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var clienteEncontrado = await CadastroContexto.Clientes.FindAsync(cliente.Id);
                    if (clienteEncontrado == null)
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View("VisualizarCliente", cliente);
        }

        public async Task<IActionResult> Apagar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await CadastroContexto.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            CadastroContexto.Clientes.Remove(cliente);
            await CadastroContexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
