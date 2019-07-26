using FormularioCadastroCliente.Data;
using Microsoft.AspNetCore.Mvc;
using FormularioCadastroCliente.Models;

namespace FormularioCadastroCliente.Controllers
{
    public class HomeController : Controller
    {
        private CadastroContexo CadastroContexo { get; }

        public HomeController(CadastroContexo cadastroContexo)
        {
            CadastroContexo = cadastroContexo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Cliente cliente)
        {
            CadastroContexo.Clientes.Add(cliente);
            CadastroContexo.SaveChanges();

            return View();
        }
    }
}
