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

    public PedidoController(IPedidoRepositorio pedidoRepo, ILogger<PedidoController> logger)
    {
        _pedidoRepositorio = pedidoRepo;
        _logger = logger;
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
}