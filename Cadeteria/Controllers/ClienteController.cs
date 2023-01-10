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
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            return View(_clienteRepositorio.ObtenerClientes());
        } else {
            return RedirectToAction("Error",new{error="No posee los permisos necesarios para ver los clientes"});
        }
        
    }

    public IActionResult Form()
    {
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            return View();
        }else{
            return RedirectToAction("Error",new{error="No posee los permisos necesarios para dar de alta un cliente"});
        }
        
    }

    [HttpGet]
    public IActionResult Baja(long ID)
    {
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            _clienteRepositorio.Baja(ID);
            ViewData["IDCliente"] = ID;
            return View();
        } else {
            return RedirectToAction("Error",new{error="No posee los permisos necesarios para dar de baja un cliente"});
        }
        
    }

    [HttpPost]
    public IActionResult Alta(Cliente cliente)
    {
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            _clienteRepositorio.Alta(cliente);
            ViewData["IDCliente"] = cliente.ID;
            return View();
        } else {
            return RedirectToAction("Error",new{error="No posee los permisos necesarios para dar de alta un cliente"});
        }
        
    }

    public ActionResult Error(string error)
    {
        ViewData["error"]=error;
        return View();
    }

}