using InfinitySky_project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using InfinitySky_project.Libraries.Login;
using InfinitySky_project.Repository;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Policy;
using AspNetCore;

namespace InfinitySky_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Interfaces para cliente e login 
        private IClienteRepository? _clienteRepositorio;
        private LoginCliente _loginCliente;

        public HomeController(ILogger<HomeController> logger, IClienteRepository clienteRepositorio, LoginCliente loginCliente) //-- recurso essencial para detectar ou investigar problemas(loggs); )
        {
            _logger = logger; 
            _clienteRepositorio = clienteRepositorio;
            _loginCliente = loginCliente;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult PainelCliente()
        {
            return View();
        }


        // P�gina de Login
        public IActionResult Login()
        {

            return View();
        }

        // Carrega a a tela login
        [HttpPost]

        public IActionResult Login(Cliente cliente)
        {
            Cliente loginDB = _clienteRepositorio.Login(cliente.Email, cliente.Senha);

            if (loginDB.Email != null && loginDB.Senha != null)
            {
                _loginCliente.Login(loginDB);
                return new RedirectResult(Url.Action(nameof(PainelCliente)));
            }
            else
            {
                //Erro na sess�o
                ViewData["msg"] = "Dados errados";
                return View();
            }
        }


        //Criando pagina cadastro cliente

        //criar 2 -> pagina cadastro que enviar os dados (POST)



        public IActionResult CadastrarCliente()
        {
            return View();
        }

        //Vai vir como se fosse uma copia 
        //inicialmente com erro -> ligar com a model Cliente -> erro sai 
        // TODAS AS MODELS COM LETRAS MAIUSCULAS 
        //QUANDO FOR INSTANCIAR COMO COM LETRA minuscula


        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente) //criando uma inst�ncia 
        {
            //M�TODO CADASTRAR

            //Para priorizar
            _clienteRepositorio.Cadastrar(cliente); //pegando a instancia de cima 

            return RedirectToAction(nameof(PainelCliente)); //nameoff-> variavel que busca alguma coisa
        }


        /*Criando uma nova view para a pagina sobre n�s*/
        public IActionResult Sobre()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
