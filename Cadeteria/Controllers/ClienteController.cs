using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cadeteria.Models;
using Cadeteria.Repositorios;
using Cadeteria.ViewModels;
namespace Cadeteria.Controllers;

public class ClienteController:Controller
{
    private readonly IClienteRepositorio _clienteRepositorio;

    private readonly ILogger<ClienteController> _logger;


    public ClienteController(IClienteRepositorio clienteRepo, ILogger<ClienteController> logger)
    {
        _logger = logger;
        _clienteRepositorio = clienteRepo;
    }

    public IActionResult MostrarClientes()
    {
        return View(_clienteRepositorio.ObtenerClientes());
    }

    public IActionResult Form()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Baja(long ID)
    {
        _clienteRepositorio.Baja(ID);
        ViewData["IDCliente"] = ID;
        return View();
    }

    [HttpPost]
    public IActionResult Alta(Cliente cliente)
    {
        _clienteRepositorio.Alta(cliente);
        ViewData["IDCliente"] = cliente.ID;
        return View();
    }

}