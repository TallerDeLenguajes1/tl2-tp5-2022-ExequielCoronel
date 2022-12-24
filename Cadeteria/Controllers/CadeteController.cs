using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cadeteria.Models;
using Cadeteria.Repositorios;
using Cadeteria.ViewModels;
namespace Cadeteria.Controllers;

public class CadeteController : Controller
{
    private readonly ILogger<CadeteController> _logger;

    private readonly ICadeteRepositorio _cadeteRepositorio;

    public CadeteController(ICadeteRepositorio cadeteRepo, ILogger<CadeteController> logger)
    {
        _cadeteRepositorio = cadeteRepo;
        _logger = logger;
    }
    public IActionResult Form()
    {
        
        return View();
    }

    [HttpPost]
    public IActionResult Alta(CadeteViewModel cadete)
    {
        if(ModelState.IsValid)
        {
            Cadete nuevoCadete = new Cadete(cadete.Nombre,cadete.Direccion,cadete.Telefono);
            _cadeteRepositorio.Alta(nuevoCadete);
        }
        return View();
    }

    public IActionResult MostrarCadetes()
    {
        return View(_cadeteRepositorio.ObtenerCadetes());
    }

    [HttpGet]
    public IActionResult Baja(int id)
    {
        _cadeteRepositorio.Baja(id);
        ViewData["IDCadete"] = id;
        return View();
    }

    [HttpGet]
    public IActionResult Editar(long id)
    {
        Cadete cadete = _cadeteRepositorio.ObtenerCadetePorID(id);
        return View(cadete);
    }

    [HttpPost]

    public IActionResult ConfirmarEditado(Cadete cadete)
    {
        _cadeteRepositorio.Editar(cadete);
        ViewData["IDCadete"] = cadete.ID;
        return View();
    }
}