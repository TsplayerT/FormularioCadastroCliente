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
            //var url = "https://www.receitaws.com.br/v1/cnpj/05113859000120";
            //using (var wc = new WebClient())
            //{
            //    var json = wc.DownloadString(url);
            //    var empresa = JsonConvert.DeserializeObject<Empresa>(json);
            //}

            return View();
        }

        [HttpPost]
        public ActionResult Index(Cliente cliente)
        {
            CadastroContexo.Clientes.Add(cliente);
            CadastroContexo.SaveChanges();

            return View();
        }
    }
}
