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
        return View(_pedidoRepositorio.ObtenerPedidos());
    }

    public IActionResult Form()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Alta(AltaPedidoViewModel nuevoPedido)
    {
        
        if(ModelState.IsValid)
        {
            _pedidoRepositorio.Alta(nuevoPedido);
        }
        return View();
    }

    [HttpGet]
    public IActionResult Baja(long id)
    {
        _pedidoRepositorio.Baja(id);
        ViewData["NumPedido"] = id;
        return View();
    }

    [HttpGet]
    public IActionResult Editar(long id)
    {
        Pedido pedido = _pedidoRepositorio.ObtenerPedidoPorNumero(id);
        return View(pedido);
    }

    [HttpPost]
    public IActionResult ConfirmarEditado(uint Numero, string Estado, string Observacion)
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
    }

    [HttpGet]
    public IActionResult AsignarCliente(long id)
    {
        List<Cliente> Clientes = _clienteRepositorio.ObtenerClientes();
        ViewData["NumPedido"] = id;
        return View(Clientes);
    }

    [HttpGet]

    public IActionResult ConfirmarAsignacionCliente(long idCliente, long idPedido)
    {
        _pedidoRepositorio.AsignarCliente(idPedido, idCliente);
        return View();
    }

    [HttpGet]
    public IActionResult AsignarCadete(long id)
    {
        List<Cadete> Cadetes = _cadeteRepositorio.ObtenerCadetes();
        ViewData["NumPedido"] = id;
        return View(Cadetes);
    }

    [HttpGet]
    public IActionResult ConfirmarAsignacionCadete(long idCadete, long idPedido)
    {
        _pedidoRepositorio.AsignarCadete(idPedido, idCadete);
        return View();
    }
}