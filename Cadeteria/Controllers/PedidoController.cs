using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cadeteria.Models;
using Cadeteria.Repositorios;
using Cadeteria.ViewModels;

namespace Cadeteria.Controllers;

public class PedidoController : Controller
{
    private readonly ILogger<PedidoController> _logger;

    private readonly IPedidoRepositorio _pedidoRepositorio;

    private readonly IClienteRepositorio _clienteRepositorio;

    private readonly ICadeteRepositorio _cadeteRepositorio;

    public PedidoController(IPedidoRepositorio pedidoRepo, ILogger<PedidoController> logger, IClienteRepositorio clienterepo, ICadeteRepositorio cadeterepo)
    {
        _pedidoRepositorio = pedidoRepo;
        _logger = logger;
        _clienteRepositorio = clienterepo;
        _cadeteRepositorio = cadeterepo;
    }

    public IActionResult MostrarPedidos()
    {
        if(HttpContext.Session.GetInt32("nombre") is not null)
        {
            return View(_pedidoRepositorio.ObtenerPedidos());
        } else {
            return RedirectToAction("Error",new{error=1});
        }
        
    }

    public IActionResult Form()
    {
        if(HttpContext.Session.GetInt32("rol") == 2)
        {
            return View();
        }else{
            return RedirectToAction("Error", new {error="No posee los permisos necesarios para dar de alta un pedido"});
        }
        
    }

    [HttpPost]
    public IActionResult Alta(AltaPedidoViewModel nuevoPedido)
    {
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            if(ModelState.IsValid)
            {
                _pedidoRepositorio.Alta(nuevoPedido);
            }
            return View();
        } else {
            return RedirectToAction("Error", new {error="No posee los permisos necesarios para dar de alta un pedido"});
        }
    }

    [HttpGet]
    public IActionResult Baja(long id)
    {
        if(HttpContext.Session.GetInt32("rol") == 2)
        {
            _pedidoRepositorio.Baja(id);
            ViewData["NumPedido"] = id;
            return View();
        } else {
            return RedirectToAction("Error", new {error="No posee los permisos necesarios para dar de baja un pedido"});
        }
        
    }

    [HttpGet]
    public IActionResult Editar(long id)
    {
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            Pedido pedido = _pedidoRepositorio.ObtenerPedidoPorNumero(id);
            return View(pedido);
        } else {
            return RedirectToAction("Error", new {error="No posee los permisos necesarios para editar un pedido"});
        }
        
    }

    [HttpPost]
    public IActionResult ConfirmarEditado(uint Numero, string Estado, string Observacion)
    {
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            bool estado = false;
            if(Estado == "true")
            {
                estado = true;
            }
            Pedido pedido = new Pedido(Numero, Observacion, estado);
            _pedidoRepositorio.Editar(pedido);
            ViewData["NumPedido"] = pedido.Numero;
            return View();
        } else {
            return RedirectToAction("Error", new {error="No posee los permisos necesarios para editar un pedido"});
        }
        
    }

    [HttpGet]
    public IActionResult AsignarCliente(long id)
    {
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            List<Cliente> Clientes = _clienteRepositorio.ObtenerClientes();
            ViewData["NumPedido"] = id;
            return View(Clientes);
        } else {
            return RedirectToAction("Error",new {error="No posee los permisos necesarios para asignar un cliente al pedido"});
        }
    }

    [HttpGet]

    public IActionResult ConfirmarAsignacionCliente(long idCliente, long idPedido)
    {
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            _pedidoRepositorio.AsignarCliente(idPedido, idCliente);
            return View();
        } else {
            return RedirectToAction("Error",new{error="No posee los permisos necesarios para asignar un cliente al pedido"});
        }
        
    }

    [HttpGet]
    public IActionResult AsignarCadete(long id)
    {
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            List<Cadete> Cadetes = _cadeteRepositorio.ObtenerCadetes();
            ViewData["NumPedido"] = id;
            return View(Cadetes);
        } else {
            return RedirectToAction("Error",new{error="No posee los permisos necesarios para asignar un cadete al pedido"});
        }
        
    }

    [HttpGet]
    public IActionResult ConfirmarAsignacionCadete(long idCadete, long idPedido)
    {
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            _pedidoRepositorio.AsignarCadete(idPedido, idCadete);
            return View();
        } else {
            return RedirectToAction("Error",new{error="No posee los permisos necesarios para asignar un cadete al pedido"});
        }
        
    }

    public ActionResult Error(string error)
    {
        if(error=="1")
        {
            ViewData["error"]="No inicio Sessión";
            ViewData["NumError"]=1;
        } else {
            ViewData["error"]=error;
        }
        
        return View();
    }
}